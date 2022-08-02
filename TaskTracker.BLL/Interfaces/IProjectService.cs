using TaskTracker.BLL.DTO.ProjectDto;

namespace TaskTracker.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAll();
        Task<ProjectDto> GetById(int id);
        Task<int> CreateProject(ProjectDto projectDto);
        Task UpdateProject(ProjectDto projectDto);
        Task DeleteProject(int id);
    }
}
