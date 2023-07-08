using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface INewsLike
    {
        Task<IEnumerable<NewsLike>> GetNewsLikeByNewsIdAsync(int NewsId);
        Task<NewsLike> GetByIdAsync(int Id);
        Task<IActionResult> AddAsync(NewsLike newsLike);
        Task<NewsLike> UpdateAsync(NewsLike newsLike);
        Task<NewsLike> DeleteAsync(int Id);
    }
}
