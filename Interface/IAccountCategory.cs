using ERP.Models;

namespace ERP.Interface
{
    public interface IAccountCategory
    {
        Task<IEnumerable<AccountCategory>> GetAllAsync();
        Task<AccountCategory> GetByIdAsync(int Id);
        Task<AccountCategory> AddAsync(AccountCategory accountCategory);
        Task<AccountCategory> UpdateAsync(AccountCategory accountCategory);
        Task<AccountCategory> DeleteAsync(int Id);
    }
}
