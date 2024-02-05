using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TasksAPI.Models.Domain;

namespace TasksAPI.Models.DTO
{
    public class BoardRequestDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
