using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskTracker.BLL.DTO.Task;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Contract;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectTaskService> _logger;

        public ProjectTaskService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectTaskService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TaskDto>> GetAll()
        {
            var entities = await _unitOfWork.ProjectTaskRepository.GetAll();
            return _mapper.Map<IEnumerable<TaskDto>>(entities);
        }

        public async Task<TaskDto> GetById(int id)
        {
            var entity = await _unitOfWork.ProjectTaskRepository.GetById(id);
            if (entity == null) throw new ArgumentNullException();
            return _mapper.Map<TaskDto>(entity);
        }

        public async Task<int> CreateProjectTask(TaskDtoCreate taskDtoCreate)
        {
            return await _unitOfWork.ProjectTaskRepository.Add(_mapper.Map<ProjectTask>(taskDtoCreate));
        }

        public async Task UpdateProjectTask(TaskDtoUpdate taskDto)
        {
            var entity = await _unitOfWork.ProjectTaskRepository.GetById(taskDto.Id);
            if (entity == null) throw new ArgumentNullException();
            _unitOfWork.ProjectTaskRepository.Update(_mapper.Map<ProjectTask>(taskDto));
        }

        public async Task DeleteProjectTask(int id)
        {
            var entity = await _unitOfWork.ProjectTaskRepository.GetById(id);
            if (entity == null) throw new ArgumentNullException();
            _unitOfWork.ProjectTaskRepository.Delete(id);
        }
    }
}
