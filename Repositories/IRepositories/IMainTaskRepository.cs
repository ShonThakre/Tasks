using TasksAPI.Models.Domain;

namespace TasksAPI.Repositories.IRepositories
{
    public interface IMainTaskRepository

    {
        Task<List<MainTask>> GetAllAsync(int TaskListId);
        Task<MainTask> CreateAsync(MainTask mainTask);
        Task<MainTask?> UpdateAsync(int id, MainTask mainTask);
        Task<MainTask?> DeleteAsync(int id);
        Task<MainTask?> GetAsync(int id);

    }
}
