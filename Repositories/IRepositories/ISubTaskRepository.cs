using TasksAPI.Models.Domain;

namespace TasksAPI.Repositories.IRepositories
{
    public interface ISubTaskRepository

    {
        Task<List<SubTask>> GetAllAsync(int mainTaskId);
        Task<SubTask> CreateAsync(SubTask subTask);
        Task<SubTask?> UpdateAsync(int id, SubTask subTask);
        Task<SubTask?> DeleteAsync(int id);
        Task<SubTask?> GetAsync(int id);

    }
}
