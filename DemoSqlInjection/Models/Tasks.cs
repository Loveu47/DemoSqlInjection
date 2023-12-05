using System.ComponentModel.DataAnnotations;

namespace DemoSqlInjection.Models
{
    public class Tasks
    {
        [Key]   
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
