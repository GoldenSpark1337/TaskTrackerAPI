using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Data
{
    public class TaskTrackerContext : DbContext
    {
        #region ctors

        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options)
        {
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }

        #region DataSet

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectTask> Tasks => Set<ProjectTask>();

        #endregion
    }
}
