using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DAL.Models
{
    public class ProjectTask : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
