using TasksAPI.Models.Domain;

namespace TasksAPI.Repositories.IRepositories
{
    public interface ITaskListRepository
    {
        Task<List<TaskList>> GetAllAsync(int boardId);
        Task<TaskList> CreateAsync(TaskList taskList);
        Task<TaskList?> UpdateAsync(int id,TaskList taskList);
        Task<TaskList?> DeleteAsync(int id);
        Task<TaskList?> GetAsync(int id);

    }
}
