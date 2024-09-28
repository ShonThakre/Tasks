using System.ComponentModel.DataAnnotations;
using TasksAPI.Models.Domain;

namespace TasksAPI.Models.DTO
{
    public class MainTaskDTO
    {
        
        public int Id { get; set; }
       
        public int TaskListId { get; set; } // Foreign key to TaskList
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Status { get; set; } 
        
        public int Sequence { get; set; }
        
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;

        public ICollection<SubTaskDTO> SubTasks { get; set; }
    }
}
