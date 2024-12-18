using ERP.Models;

namespace ERP.Interface
{
    public interface IVillage
    {
        Task<IEnumerable<Village>> GetAllAsync();
        Task<Village> GetByIdAsync(int Id);
        Task<Village> AddAsync(Village village);
        Task<Village> UpdateAsync(Village village);
        Task<Village> DeleteAsync(int Id);
        Task<IEnumerable<Village>> GetVillageByCityIdAsync(int Id);
    }
}
