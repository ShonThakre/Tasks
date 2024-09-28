using System.ComponentModel.DataAnnotations;
using TasksAPI.Models.Domain;

namespace TasksAPI.Models.DTO
{
    public class BoardDTO
    {
        public int Id { get; set; }
 
        public string Title { get; set; }

        public string Status { get; set; }

        public DateTime EntryDate { get; set; } 

        public string UserId { get; set; }

        public ICollection<TaskListDTO> TaskLists { get; set; } // for the respective tasklist

    }
}
