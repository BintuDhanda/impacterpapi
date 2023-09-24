using ERP.Models;
using ERP.SearchFilters;

namespace ERP.Interface
{
    public interface INews
    {
        Task<IEnumerable<News>> GetAllAsync(NewsSearchFilter newsSearchFilter);
        Task<IEnumerable<News>> GetAllNewsAsync(NewsSearchFilter newsSearchFilter);
        Task<News> GetByIdAsync(int Id);
        Task<News> AddAsync(News news);
        Task<News> UpdateAsync(News news);
        Task<News> DeleteAsync(int Id);
    }
}
