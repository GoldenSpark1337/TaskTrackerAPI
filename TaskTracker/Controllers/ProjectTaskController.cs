using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.BLL.DTO.Task;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Entities;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IMapper _mapper;

        public ProjectTaskController(IProjectTaskService projectTaskService, IMapper mapper)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAllAsync()
        {
            var entities = await _projectTaskService.GetAll();
            return Ok(_mapper.Map<IEnumerable<TaskDto>>(entities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetByIdAsync(int id)
        {
            var entity = await _projectTaskService.GetById(id);
            return Ok(_mapper.Map<TaskDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProjectTaskAsync(TaskDtoCreate taskDtoCreate)
        {
            return Ok(await _projectTaskService.CreateProjectTask(taskDtoCreate));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTaskStatus(TaskDtoUpdate taskDtoUpdate)
        {
            return Ok(_projectTaskService.UpdateProjectTask(taskDtoUpdate));
        }

        [HttpPatch]
        public async Task<ActionResult> PatchTaskStatus(TaskDtoUpdate taskDtoUpdate)
        {
            return Ok(_projectTaskService.UpdateProjectTask(taskDtoUpdate));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTaskStatus(int id)
        {
            return Ok(_projectTaskService.DeleteProjectTask(id));
        }
    }
}
