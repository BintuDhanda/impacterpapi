using ERP.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.Interface
{
    public interface IUniversity
    {
        Task<IEnumerable<University>> GetAllAsync();
        Task<University> GetByIdAsync(int Id);
        Task<University> AddAsync(University university);
        Task<University> UpdateAsync(University university);
        Task<University> DeleteAsync(int Id);
    }
}
