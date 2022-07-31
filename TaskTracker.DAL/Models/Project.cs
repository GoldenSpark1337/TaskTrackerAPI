namespace TaskTracker.DAL.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
