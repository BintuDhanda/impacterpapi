using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class BoardRepository : IBoard
    {
        private readonly AppDbContext _appDbContext;
        public BoardRepository(AppDbContext apDbContext)
        {
            _appDbContext = apDbContext;
        }
        public async Task<IEnumerable<Board>> GetAllAsync()
        {
            return await _appDbContext.Board.ToListAsync();
        }
        public async Task<Board> GetByIdAsync(int Id)
        {
            return await _appDbContext.Board.FindAsync(Id);
        }
        public async Task<Board> AddAsync(Board board)
        {
            _appDbContext.Board.Add(board);
            await _appDbContext.SaveChangesAsync();
            return board;
        }
        public async Task<Board> UpdateAsync(Board board)
        {
            _appDbContext.Board.Update(board);
            await _appDbContext.SaveChangesAsync();
            return board;
        }
        public async Task<Board> DeleteAsync(int Id)
        {
            var board = await _appDbContext.Board.FindAsync(Id);
            _appDbContext.Board.Remove(board);
            await _appDbContext.SaveChangesAsync();
            return board;
        }
    }
}
