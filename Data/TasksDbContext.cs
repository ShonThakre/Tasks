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

       public DbSet<MainTask> MainTasks { get; set; } 
       public DbSet<Board> Boards { get; set; }
       public DbSet<TaskList> TaskLists { get; set; }
       public DbSet<SubTask> SubTasks { get; set; }
    }
}
