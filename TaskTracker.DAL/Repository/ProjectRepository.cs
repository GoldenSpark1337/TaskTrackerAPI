using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Data;
using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Repository
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly TaskTrackerContext _dbContext;

        public ProjectRepository(TaskTrackerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _dbContext.Projects.ToListAsync();
        }   

        public async Task<Project> GetById(int id)
        {
            return await _dbContext.Projects.FindAsync(id) 
                ?? throw new ArgumentNullException($"Entity with {id} was not found.");
        }

        public async Task<int> Add(Project project)
        { 
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
