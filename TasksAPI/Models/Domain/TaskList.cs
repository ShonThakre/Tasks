using System.ComponentModel.DataAnnotations;

namespace TasksAPI.Models.Domain
{
    public class TaskList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Status { get; set; } = "Y";
        public int Sequence { get; set; }
        public DateTime EntryDate { get; set; }
        public int BoardId { get; set; } // Foreign key to Board

        // Navigation properties
        public Board Board { get; set; }
        public ICollection<MainTask> MainTasks { get; set; }
    }
}
