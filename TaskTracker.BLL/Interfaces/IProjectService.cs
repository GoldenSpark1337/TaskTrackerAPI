using TaskTracker.BLL.DTO.Project;
using TaskTracker.BLL.DTO.ProjectDto;

namespace TaskTracker.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAll();
        Task<ProjectDto> GetById(int id);
        Task<int> CreateProject(ProjectDtoCreate projectDto);
        Task UpdateProject(ProjectDtoUpdate projectDto);
        Task DeleteProject(int id);
    }
}
