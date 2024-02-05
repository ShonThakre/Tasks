﻿using TasksAPI.Models.Domain;

namespace TasksAPI.Repositories
{
    public interface IBoardRepository
    {
        Task<List<Board>> GetAllAsync();
        Task<Board> CreateAsync(Board board);
        Task<Board?> UpdateAsync(int id, Board board);
        Task<Board?> DeleteAsync(int id);
    }
}
