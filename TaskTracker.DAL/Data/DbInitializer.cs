namespace TaskTracker.DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TaskTrackerContext context)
        {
            context.Database.EnsureCreated(); 
        }
    }
}
