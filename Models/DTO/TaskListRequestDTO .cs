using System.ComponentModel.DataAnnotations;

namespace TasksAPI.Models.DTO
{
    public class TaskListRequestDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Sequence { get; set; }

        [Required]
        public int BoardId { get; set; } 

    }
}
