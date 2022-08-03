using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.DTO.Task
{
    public class TaskDtoCreate : IMapWith<ProjectTask>
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        public string Description { get; set; }
        [Range(1, 4, ErrorMessage = "Priority range must be between 1-4")]
        public int Priority { get; set; } = 1;
        [Required]
        public int ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskDtoCreate, ProjectTask>();
        }
    }
}
