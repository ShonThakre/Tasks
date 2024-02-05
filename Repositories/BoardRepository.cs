using TasksAPI.Data;
using TasksAPI.Models.Domain;

namespace TasksAPI.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly TasksDbContext _Context;


        public BoardRepository(TasksDbContext tasksDbContext)
        {
            _Context = tasksDbContext;
        }

        public async Task<Board> CreateAsync(Board board)
        {
           await _Context.Boards.AddAsync(board);
            await _Context.SaveChangesAsync();
            return board;
        }

        public Task<Board?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Board>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Board?> UpdateAsync(Guid id, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
