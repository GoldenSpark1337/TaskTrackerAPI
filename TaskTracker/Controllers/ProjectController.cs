using Microsoft.AspNetCore.Mvc;
using TaskTracker.BLL.DTO.Project;
using TaskTracker.BLL.DTO.ProjectDto;
using TaskTracker.BLL.Interfaces;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
        {
            return Ok(await _projectService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetById(int id)
        {
            return Ok(await _projectService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProject(ProjectDtoCreate projectDto)
        {
            return Ok(await _projectService.CreateProject(projectDto));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProject(ProjectDtoUpdate projectDtoUpdate)
        {
            return Ok(_projectService.UpdateProject(projectDtoUpdate));
        }

        [HttpPatch]
        public async Task<ActionResult> PatchProject(ProjectDtoUpdate projectDtoUpdate)
        {
            return Ok(_projectService.UpdateProject(projectDtoUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            return Ok(_projectService.DeleteProject(id));
        }
    }
}
