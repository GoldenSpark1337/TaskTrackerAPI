namespace TaskTracker.BLL.Interfaces
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateProjectAsync(T entity);
        Task UpdateProjectAsync(T entity);
        Task DeleteProjectAsync(int id);
    }
}
