using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TaskTracker.BLL.Interfaces;

namespace TaskTracker.BLL.DTO.Project
{
    public class ProjectDtoCreate : IMapWith<DAL.Entities.Project>
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Range(1, 4, ErrorMessage = "Priority range must be between 1-4")]
        public int Priority { get; set; } = 1;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectDtoCreate, DAL.Entities.Project>();
            profile.CreateMap<DAL.Entities.Project, ProjectDtoCreate>();
        }
    }
}
