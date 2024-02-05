using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasksAPI.Models.Domain;

namespace TasksAPI.Data
{
    public class TasksDbContext : IdentityDbContext
    {
        public TasksDbContext(DbContextOptions options): base(options) 
        {
            
        }

        DbSet<MainTask> MainTasks { get; set; } 
        DbSet<Board> Boards { get; set; }
        DbSet<TaskList> TaskLists { get; set; }
        DbSet<SubTask> SubTasks { get; set; }
    }
}
