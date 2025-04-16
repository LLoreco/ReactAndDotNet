using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.Server.Data
{
    [Table("Tasks", Schema = "public")]
    public class Tasks
    {
        [Key]
        public int id { get; set; }
        public string TaskName { get; set; }
        public DateTimeOffset TaskCreated { get; set; }
        public DateTimeOffset TaskTime { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }

    }
}
