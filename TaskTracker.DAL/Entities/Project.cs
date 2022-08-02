using System.ComponentModel.DataAnnotations;
using TaskTracker.DAL.Enums;

namespace TaskTracker.DAL.Entities
{
    public class Project : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;
        [Range(1, 4, ErrorMessage = "Value for {0} must be between {1} and {2}.")]  
        public int Priority { get; set; } = 1;              // Priority values: High, Medium, Low, Lowest 

        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
