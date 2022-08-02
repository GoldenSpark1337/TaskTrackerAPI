using AutoMapper;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.DTO.Task
{
    internal class TaskDtoCreate : IMapWith<ProjectTask>
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskDtoCreate, ProjectTask>();
        }
    }
}
