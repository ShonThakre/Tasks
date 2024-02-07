using System.ComponentModel.DataAnnotations;
using TasksAPI.Models.Domain;

namespace TasksAPI.Models.DTO
{
    public class TaskListDTO
    {
        public int Id { get; set; }    

        public string Title { get; set; }

        public string Status { get; set; } 

        public int Sequence { get; set; }

        public DateTime EntryDate { get; set; }

        public int BoardId { get; set; }

        public ICollection<MainTaskDTO> MainTasks { get; set; }

    }
}
