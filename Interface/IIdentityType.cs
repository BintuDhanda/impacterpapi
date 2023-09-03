using ERP.Models;

namespace ERP.Interface
{
    public interface IIdentityType
    {
        Task<IEnumerable<IdentityType>> GetAllAsync();
        Task<IdentityType> GetByIdAsync(int Id);
        Task<IdentityType> AddAsync(IdentityType address);
        Task<IdentityType> UpdateAsync(IdentityType address);
        Task<IdentityType> DeleteAsync(int Id);
    }
}
