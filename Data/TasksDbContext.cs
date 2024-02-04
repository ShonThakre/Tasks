using Microsoft.EntityFrameworkCore;

namespace TasksAPI.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions options): base(options) 
        {
            
        }
    }
}
