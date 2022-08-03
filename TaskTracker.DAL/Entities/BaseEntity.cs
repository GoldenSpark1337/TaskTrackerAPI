namespace TaskTracker.DAL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? FinishedAt { get; set; }
    }
}
