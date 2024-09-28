using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TasksAPI.Models.Domain
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Status { get; set; } = "Y";
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; } // Foreign key to IdentityUser

        // Navigation property
        public IdentityUser User { get; set; }
        public ICollection<TaskList> TaskLists { get; set; }
    }
}
