using ERP.Models;

namespace ERP.Interface
{
    public interface IHostelRoomBadStudent
    {
        Task<IEnumerable<HostelRoomBadStudent>> GetAllAsync();
        Task<HostelRoomBadStudent> GetByIdAsync(int Id);
        Task<HostelRoomBadStudent> AddAsync(HostelRoomBadStudent payload);
        Task<HostelRoomBadStudent> UpdateAsync(HostelRoomBadStudent payload);
        Task<HostelRoomBadStudent> DeleteAsync(int Id);
    }
}
