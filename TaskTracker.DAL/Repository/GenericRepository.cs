using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Data;
using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TaskTrackerContext _context;

        public GenericRepository(TaskTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity ?? throw new ArgumentNullException(nameof(id));
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().FindAsync(id).Result;
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }       
    }
}
