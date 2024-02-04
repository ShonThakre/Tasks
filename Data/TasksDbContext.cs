using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TasksAPI.Data
{
    public class TasksDbContext : IdentityDbContext
    {
        public TasksDbContext(DbContextOptions options): base(options) 
        {
            
        }
    }
}
