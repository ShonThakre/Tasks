using System.ComponentModel.DataAnnotations;
using TasksAPI.Models.Domain;

namespace TasksAPI.Models.DTO
{
    public class SubTaskDTO
    {

        public int Id { get; set; }

        public int MainTaskId { get; set; } 

        public string Title { get; set; }

        public bool Status { get; set; } = true;

        public DateTime EntryDate { get; set; } = DateTime.UtcNow;

    }
}
