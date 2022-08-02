using System.Collections;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Entities;
using Microsoft.Extensions.Logging;
using TaskTracker.DAL.Data;

namespace TaskTracker.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskTrackerContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;
        private Hashtable _repositories;

        public UnitOfWork(TaskTrackerContext dbContext, ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IRepository<Project> ProjectRepository => new ProjectRepository(_dbContext);
        public IRepository<ProjectTask> ProjectTaskRepository => new ProjectTaskRepository(_dbContext);

        /// <summary>
        /// Generic Repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                _logger.LogDebug(repositoryType.FullName);
                _logger.LogDebug(repositoryType.Name);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }

        public async Task<bool> Complete()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
