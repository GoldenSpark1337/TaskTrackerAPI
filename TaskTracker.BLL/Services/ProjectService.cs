using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskTracker.BLL.DTO.Project;
using TaskTracker.BLL.DTO.ProjectDto;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            var projects = await _unitOfWork.ProjectRepository.GetAll();
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> GetById(int id)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<int> CreateProject(ProjectDtoCreate projectDto)
        {
            if (projectDto == null)
            {
                _logger.LogError("Create failed"); // TODO: validation
                throw new ArgumentNullException(nameof(projectDto));
            }
            return await _unitOfWork.ProjectRepository.Add(_mapper.Map<Project>(projectDto));
        }

        public async Task UpdateProject(ProjectDtoUpdate projectDto)
        {
            _logger.LogDebug($"{projectDto.Name} status {projectDto.Status}");
            _unitOfWork.ProjectRepository.Update(_mapper.Map<Project>(projectDto));
        }

        public async Task DeleteProject(int id)
        {
            _unitOfWork.ProjectRepository.Delete(id);
        }
    }
}
