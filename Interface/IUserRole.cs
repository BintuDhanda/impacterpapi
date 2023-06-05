using ERP.Models;

namespace ERP.Interface
{
    public interface IUserRole
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> GetByIdAsync(int Id);
        Task<UserRole> AddAsync(UserRole userRole);
        Task<UserRole> UpdateAsync(UserRole userRole);
        Task<UserRole> DeleteAsync(int Id);
        Task<IEnumerable<UserRole>> GetByUserIdAsync(int userId);
    }
}
