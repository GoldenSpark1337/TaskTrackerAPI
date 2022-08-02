using AutoMapper;
using TaskTracker.BLL.Interfaces;

namespace TaskTracker.BLL.DTO.Project
{
    public class ProjectDtoCreate : IMapWith<DAL.Entities.Project>
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectDtoCreate, DAL.Entities.Project>();
        }
    }
}
