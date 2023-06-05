using ERP.Models;

namespace ERP.Interface
{
    public interface IBoard
    {
        Task<IEnumerable<Board>> GetAllAsync();
        Task<Board> GetByIdAsync(int Id);
        Task<Board> AddAsync(Board board);
        Task<Board> UpdateAsync(Board board);
        Task<Board> DeleteAsync(int Id);
    }
}
