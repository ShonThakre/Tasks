using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using TasksAPI.Models.Domain;
using TasksAPI.Repositories.IRepositories;

namespace TasksAPI.Repositories
{
    public class SubTaskRepository : ISubTaskRepository
    {
        private readonly TasksDbContext _dbContext;

        public SubTaskRepository(TasksDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<SubTask> CreateAsync(SubTask SubTask)
        {
            await _dbContext.SubTasks.AddAsync(SubTask);
            await _dbContext.SaveChangesAsync();
            return SubTask;

        }

        public async Task<SubTask?> DeleteAsync(int id)
        {
           var existingSubTask = await _dbContext.SubTasks.FirstOrDefaultAsync(l => l.Id == id);
            if (existingSubTask == null)
            {
                return null;
            }

            _dbContext.SubTasks.Remove(existingSubTask);
            _dbContext.SaveChanges();
            return existingSubTask;
        }

        public async Task<SubTask?> GetAsync(int id)
        {
            var task = await _dbContext.SubTasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public async Task<List<SubTask>> GetAllAsync(int mainTaskId)
        {
            //for complete nested data 
            var list = await _dbContext.SubTasks
                 .Where(x => x.MainTaskId == mainTaskId)
                 .ToListAsync();
            return list;
        }

        public async Task<SubTask?> UpdateAsync(int id, SubTask SubTask)
        {
           var existingSubTask = await _dbContext.SubTasks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingSubTask == null)
            {
                return null;
            }

            //existingSubTask.MainTaskId = SubTask.MainTaskId;
            existingSubTask.Title = SubTask.Title;
            existingSubTask.Status = SubTask.Status;

            await _dbContext.SaveChangesAsync();

            return existingSubTask; 


        }


    }
}
