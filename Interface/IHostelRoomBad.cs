using ERP.Models;

namespace ERP.Interface
{
    public interface IHostelRoomBad
    {
        Task<IEnumerable<HostelRoomBad>> GetAllAsync(int Id);
        Task<IEnumerable<HostelRoomBad>> GetAllUnallocatedAsync(int Id);
        Task<HostelRoomBad> GetByIdAsync(int Id);
        Task<HostelRoomBad> AddAsync(HostelRoomBad payload);
        Task<HostelRoomBad> UpdateAsync(HostelRoomBad payload);
        Task<HostelRoomBad> DeleteAsync(int Id);
    }
}
