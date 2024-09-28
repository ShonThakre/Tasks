using System.ComponentModel.DataAnnotations;

namespace TasksAPI.Models.Domain
{
    public class SubTask
    {
        [Key]
        public int Id { get; set; }
        public int MainTaskId { get; set; } // Foreign key to Task
        [Required]
        public string Title { get; set; }
        [Required]
        public bool Status { get; set; } = true;
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;

        // Navigation property
        public MainTask MainTask { get; set; }
    }
}
