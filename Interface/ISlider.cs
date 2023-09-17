using ERP.Models;
using ERP.SearchFilters;

namespace ERP.Interface
{
    public interface ISlider
    {
        Task<IEnumerable<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int Id);
        Task<Slider> AddAsync(Slider slider);
        Task<Slider> UpdateAsync(Slider slider);
        Task<Slider> DeleteAsync(int Id);
    }
}
