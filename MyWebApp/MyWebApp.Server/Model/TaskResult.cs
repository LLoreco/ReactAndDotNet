namespace MyWebApp.Server.Model
{
    public class TaskResult <T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
