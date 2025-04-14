namespace MyWebApp.Server.Model
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskTime { get; set; }
        public bool IsCompleted { get; set; }
    }
}
