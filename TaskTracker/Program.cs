using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using TaskTracker.BLL.Common;
using TaskTracker.BLL.Interfaces;
using TaskTracker.BLL.Services;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Data;
using TaskTracker.DAL.Repository;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers().AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
    builder.Services.AddScoped<IProjectService, ProjectService>();
    builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();


    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<TaskTrackerContext>(opt =>
    {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"))
            .UseSnakeCaseNamingConvention(); // To use snakeCase in PostgreSql
    });

    // Automapper
    //builder.Services.AddAutoMapper(typeof(IMapWith<>));
    builder.Services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(typeof(AssemblyMappingProfile).Assembly));
    });

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var context = serviceProvider.GetRequiredService<TaskTrackerContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception exception)
        {
            logger.Error(exception, exception.Message);
            throw;
        }
        
    }

    app.MapControllers();

    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, exception.Message);
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
