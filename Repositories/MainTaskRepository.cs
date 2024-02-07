using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using TasksAPI.Models.Domain;
using TasksAPI.Repositories.IRepositories;

namespace TasksAPI.Repositories
{
    public class MainTaskRepository : IMainTaskRepository
    {
        private readonly TasksDbContext _dbContext;

        public MainTaskRepository(TasksDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<MainTask> CreateAsync(MainTask MainTask)
        {
            await _dbContext.MainTasks.AddAsync(MainTask);
            await _dbContext.SaveChangesAsync();
            return MainTask;

        }

        public async Task<MainTask?> DeleteAsync(int id)
        {
           var existingMainTask = await _dbContext.MainTasks.FirstOrDefaultAsync(l => l.Id == id);
            if (existingMainTask == null)
            {
                return null;
            }

            _dbContext.MainTasks.Remove(existingMainTask);
            _dbContext.SaveChanges();
            return existingMainTask;
        }

        public async Task<MainTask?> GetAsync(int id)
        {
            var task = await _dbContext.MainTasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public async Task<List<MainTask>> GetAllAsync(int TaskListId)
        {
            //for complete nested data 
            var list = await _dbContext.MainTasks
                 .Where(x => x.TaskListId == TaskListId)
                 .Include(z => z.SubTasks)
                 .ToListAsync();
            return list;
        }

        public async Task<MainTask?> UpdateAsync(int id, MainTask MainTask)
        {
           var existingMainTask = await _dbContext.MainTasks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingMainTask == null)
            {
                return null;
            }

            existingMainTask.TaskListId = MainTask.TaskListId;
            existingMainTask.Title = MainTask.Title;
            existingMainTask.Description = MainTask.Description;
            existingMainTask.Sequence = MainTask.Sequence;
            existingMainTask.Status = MainTask.Status;

            await _dbContext.SaveChangesAsync();

            return existingMainTask; 


        }


    }
}
