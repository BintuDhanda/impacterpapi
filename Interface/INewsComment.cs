using ERP.Models;

namespace ERP.Interface
{
    public interface INewsComment
    {
        Task<IEnumerable<NewsComment>> GetAllAsync();
        Task<NewsComment> GetByIdAsync(int Id);
        Task<NewsComment> AddAsync(NewsComment newsComment);
        Task<NewsComment> UpdateAsync(NewsComment newsComment);
        Task<NewsComment> DeleteAsync(int Id);
    }
}
