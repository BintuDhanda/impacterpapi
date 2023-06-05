using ERP.Models;

namespace ERP.Interface
{
    public interface ICountry
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int Id);
        Task<Country> AddAsync(Country country);
        Task<Country> UpdateAsync(Country country);
        Task<Country> DeleteAsync(int Id);
    }
}
