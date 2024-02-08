using ERP.Models;

namespace ERP.Interface
{
    public interface IHostelRoomRent
    {
        Task<IEnumerable<HostelRoomRent>> GetAllAsync();
        Task<Account> GetByIdAsync(int Id);
        Task<Account> AddAsync(HostelRoomRent account);
        Task<Account> UpdateAsync(HostelRoomRent account);
        Task<Account> DeleteAsync(int Id);
        Task<IEnumerable<HostelRoomRent>> GetAccountByAccountCategoryIdAsync(int Id);
    }
}
