using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<int>> CreateProject(ProjectDto projectDto)
        {
            return Ok(await _projectService.CreateProject(projectDto));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProject(ProjectDto projectDto)
        {
            return Ok(_projectService.UpdateProject(projectDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            return Ok(_projectService.DeleteProject(id));
        }
    }
}
