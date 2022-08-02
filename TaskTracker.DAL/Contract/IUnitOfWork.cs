using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        IRepository<Project> ProjectRepository { get; }
        IRepository<ProjectTask> ProjectTaskRepository { get; }
        Task<bool> Complete();
    }
}
