using Microsoft.Extensions.Logging;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GenericService<T>> _logger;

        public GenericService(IUnitOfWork unitOfWork, ILogger<GenericService<T>> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.Repository<T>().GetAll();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.Repository<T>().GetById(id);
            if (entity == null) throw new ArgumentNullException();
            return entity;
        }

        public async Task<int> CreateProjectAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            await _unitOfWork.Repository<T>().Add(entity);
            return entity.Id;
        }

        public async Task UpdateProjectAsync(T entity)
        {
            var entityExist = await _unitOfWork.Repository<T>().GetById(entity.Id);
            if (entityExist == null) throw new ArgumentNullException();
            _unitOfWork.Repository<T>().Update(entity);
        }

        public async Task DeleteProjectAsync(int id)
        {
            var entityExist = await _unitOfWork.Repository<T>().GetById(id);
            if (entityExist == null) throw new ArgumentNullException();
            _unitOfWork.Repository<T>().Delete(id);
        }
    }
}
