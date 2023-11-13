using ERP.Models;

namespace ERP.Interface
{
    public interface IHostalRoom
    {
        Task<IEnumerable<HostelRoom>> GetAllAsync();
        Task<Account> GetByIdAsync(int Id);
        Task<Account> AddAsync(HostelRoom account);
        Task<Account> UpdateAsync(HostelRoom account);
        Task<Account> DeleteAsync(int Id);
        Task<IEnumerable<HostelRoom>> GetAccountByAccountCategoryIdAsync(int Id);
    }
}
