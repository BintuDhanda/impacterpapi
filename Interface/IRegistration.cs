using ERP.Models;

namespace ERP.Interface
{
    public interface IRegistration
    {
        Task<IEnumerable<Registration>> GetAllAsync();
        Task<Registration> GetByIdAsync(int Id);
        Task<Registration> AddAsync(Registration registration);
        Task<Registration> UpdateAsync(Registration registration);
        Task<Registration> DeleteAsync(int Id);
    }
}
