using AutoMapper;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.DTO.Task
{
    public class TaskDto : IMapWith<ProjectTask>
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Project { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap <ProjectTask, TaskDto>()
                .ForMember(dto => dto.Project, 
                    opt => opt.MapFrom(pt => pt.Project.Name));
        }
    }
}
