using System.ComponentModel.DataAnnotations;
using TasksAPI.Models.Domain;

namespace TasksAPI.Models.DTO
{
    public class MainTaskRequestDTO
    {
        [Required]
        public int TaskListId { get; set; } 
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public int Sequence { get; set; }


       // public ICollection<SubTaskDTO> SubTasks { get; set; }

    }
}
