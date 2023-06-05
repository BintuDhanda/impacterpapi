using ERP.Models;

namespace ERP.Interface
{
    public interface ICity
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City> GetByIdAsync(int Id);
        Task<City> AddAsync(City city);
        Task<City> UpdateAsync(City city);
        Task<City> DeleteAsync(int Id);
        Task<IEnumerable<City>> GetCityByStateIdAsync(int Id);
    }
}
