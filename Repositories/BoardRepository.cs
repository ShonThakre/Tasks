using Microsoft.EntityFrameworkCore;
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

        public async Task<Board?> DeleteAsync(int id)
        {
           var existingBoard =  await _Context.Boards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBoard != null)
            {
                _Context.Boards.Remove(existingBoard);
                _Context.SaveChanges();
                return existingBoard;
            }
            else
            {
                return null;
            }

        }

        public async Task<List<Board>> GetAllAsync()
        {
           var List =  await _Context.Boards.ToListAsync();

            return List;
        }

        public Task<Board?> UpdateAsync(int id, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
