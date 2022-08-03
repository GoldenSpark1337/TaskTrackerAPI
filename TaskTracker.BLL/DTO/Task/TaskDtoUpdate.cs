using AutoMapper;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.DTO.Task
{
    public class TaskDtoUpdate : IMapWith<ProjectTask>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskDtoUpdate, ProjectTask>();

        }
    }
}
