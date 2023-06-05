using ERP.Models;

namespace ERP.Interface
{
    public interface IAccount
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(int Id);
        Task<Account> AddAsync(Account account);
        Task<Account> UpdateAsync(Account account);
        Task<Account> DeleteAsync(int Id);
        Task<IEnumerable<Account>> GetAccountByAccountCategoryIdAsync(int Id);
    }
}
