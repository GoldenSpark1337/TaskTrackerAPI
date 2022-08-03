using TaskTracker.BLL.DTO.Task;

namespace TaskTracker.BLL.Interfaces
{
    public interface IProjectTaskService
    {
        Task<IEnumerable<TaskDto>> GetAll();
        Task<TaskDto> GetById(int id);
        Task<int> CreateProjectTask(TaskDtoCreate projectDto);
        Task UpdateProjectTask(TaskDtoUpdate projectDto);
        Task DeleteProjectTask(int id);
    }
}
