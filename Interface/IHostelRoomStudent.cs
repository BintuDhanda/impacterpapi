using ERP.Models;

namespace ERP.Interface
{
    public interface IHostelRoomStudent
    {
        Task<IEnumerable<HostelRoomStudent>> GetAllAsync();
        Task<Account> GetByIdAsync(int Id);
        Task<Account> AddAsync(HostelRoomStudent account);
        Task<Account> UpdateAsync(HostelRoomStudent account);
        Task<Account> DeleteAsync(int Id);
        Task<IEnumerable<HostelRoomStudent>> GetAccountByAccountCategoryIdAsync(int Id);
    }
}
