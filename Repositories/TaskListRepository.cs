using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using TasksAPI.Models.Domain;
using TasksAPI.Repositories.IRepositories;

namespace TasksAPI.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly TasksDbContext _dbContext;

        public TaskListRepository(TasksDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<TaskList> CreateAsync(TaskList taskList)
        {
            await _dbContext.TaskLists.AddAsync(taskList);
            await _dbContext.SaveChangesAsync();
            return taskList;

        }

        public async Task<TaskList?> DeleteAsync(int id)
        {
           var existingTaskLIst = await _dbContext.TaskLists.FirstOrDefaultAsync(l => l.Id == id);
            if (existingTaskLIst == null)
            {
                return null;
            }

            _dbContext.TaskLists.Remove(existingTaskLIst);
            _dbContext.SaveChanges();
            return existingTaskLIst;
        }

        public async Task<TaskList?> GetAsync(int id)
        {
            var task = await _dbContext.TaskLists.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public async Task<List<TaskList>> GetAllAsync(int boardId)
        {
            //for complete nested data 
            var list = await _dbContext.TaskLists
                 .Where(x => x.BoardId == boardId)
                 .Include(y => y.MainTasks)
                 .ThenInclude(z => z.SubTasks)
                 .ToListAsync();
            return list;
        }

        public async Task<TaskList?> UpdateAsync(int id, TaskList taskList)
        {
           var existingTaskList = await _dbContext.TaskLists.FirstOrDefaultAsync(x => x.Id == id);

            if(existingTaskList == null)
            {
                return null;
            }

            existingTaskList.Title = taskList.Title;
            existingTaskList.Sequence = taskList.Sequence;
            existingTaskList.Status = taskList.Status;

            await _dbContext.SaveChangesAsync();

            return existingTaskList; 


        }
    }
}
