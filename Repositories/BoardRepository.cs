using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using TasksAPI.Models.Domain;
using TasksAPI.Repositories.IRepositories;

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

            if (existingBoard == null)
            {
                return null;
            }

            _Context.Boards.Remove(existingBoard);
                _Context.SaveChanges();
                return existingBoard;
            
       
        }

        public async Task<List<Board>> GetAllAsync(string userId)
        {
           var List =  await _Context.Boards
                .Where(b => b.UserId == userId)
                .Include(board => board.TaskLists)
                .ThenInclude(TaskLists => TaskLists.MainTasks)
                .ThenInclude(MainTasks => MainTasks.SubTasks)
                .ToListAsync();

            return List;
        }

        public async Task<Board?> UpdateAsync(int id, Board board)
        {
            var existingBoard = await _Context.Boards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBoard == null)
            {
                return null;
            }

            existingBoard.Title = board.Title;

            await _Context.SaveChangesAsync();
            return existingBoard;
        }
    }
}
