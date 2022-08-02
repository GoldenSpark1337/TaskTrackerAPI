using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DAL.Entities
{
    public class ProjectTask : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.ToDo;
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Range(1, 4)]
        public int Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
