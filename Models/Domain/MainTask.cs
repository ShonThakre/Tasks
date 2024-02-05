using System.ComponentModel.DataAnnotations;

namespace TasksAPI.Models.Domain
{
    public class MainTask
    {
        [Key]
        public int Id { get; set; }
        public int TaskListId { get; set; } // Foreign key to TaskList
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Status { get; set; } = "Y";
        public int Sequence { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public TaskList TaskList { get; set; }
        public ICollection<SubTask> SubTasks { get; set; }
    }
}
