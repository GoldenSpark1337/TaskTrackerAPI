using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Contract
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
