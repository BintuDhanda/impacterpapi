using ERP.Models;

namespace ERP.Interface
{
    public interface IHostal
    {
        Task<IEnumerable<Hostel>> GetAllAsync();
        Task<Account> GetByIdAsync(int Id);
        Task<Account> AddAsync(Hostel account);
        Task<Account> UpdateAsync(Hostel account);
        Task<Account> DeleteAsync(int Id);
        Task<IEnumerable<Hostel>> GetAccountByAccountCategoryIdAsync(int Id);
    }
}
