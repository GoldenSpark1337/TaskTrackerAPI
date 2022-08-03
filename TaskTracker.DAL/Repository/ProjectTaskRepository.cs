using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Data;
using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Repository
{
    public class ProjectTaskRepository : IRepository<ProjectTask>
    {
        private readonly TaskTrackerContext _dbContext;

        public ProjectTaskRepository(TaskTrackerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProjectTask>> GetAll()
        {
            return await _dbContext.Tasks
                .Include(pt => pt.Project)
                .ToListAsync();
        }

        public async Task<ProjectTask> GetById(int id)
        {
            return await _dbContext.Tasks
                .Include(pt => pt.Project)
                .FirstOrDefaultAsync(pt => pt.Id == id)
                ?? throw new ArgumentNullException($"Entity with {id} was not found.");
        }

        public async Task<int> Add(ProjectTask entity)
        {
            await _dbContext.Tasks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Tasks.Find(id);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbContext.Tasks.Remove(entity);
            _dbContext.SaveChanges();

        }

        public void Update(ProjectTask projectTask)
        {
            _dbContext.Tasks.Attach(projectTask);
            _dbContext.Entry(projectTask).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
        }
    }
}
