using AutoMapper;
using TaskTracker.BLL.Interfaces;

namespace TaskTracker.BLL.DTO.Project
{
    public class ProjectDtoUpdate : IMapWith<DAL.Entities.Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime FinishedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectDtoUpdate, DAL.Entities.Project>();
        }
    }
}
