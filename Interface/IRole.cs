using ERP.Models;

namespace ERP.Interface
{
    public interface IRole
    {
        Task<IEnumerable<Roles>> GetAllAsync ();
        Task<Roles> GetByIdAsync(int Id);
        Task<Roles> AddAsync(Roles role);
        Task<Roles> UpdateAsync(Roles role);
        Task<Roles> DeleteAsync(int Id);
    }
}
