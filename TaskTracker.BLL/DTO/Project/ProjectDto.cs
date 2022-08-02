using AutoMapper;
using TaskTracker.BLL.DTO.Task;
using TaskTracker.BLL.Interfaces;

namespace TaskTracker.BLL.DTO.ProjectDto
{
    public class ProjectDto : IMapWith<DAL.Entities.Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public IEnumerable<TaskDto> Tasks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Project, ProjectDto>();
                //.ForMember(p => p.Status, opt => opt.MapFrom(p => p.Status));
        }
    }
}
