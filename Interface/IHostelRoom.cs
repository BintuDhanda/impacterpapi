using ERP.Models;

namespace ERP.Interface
{
    public interface IHostelRoom
    {
        Task<IEnumerable<HostelRoom>> GetAllAsync(int Id);
        Task<HostelRoom> GetByIdAsync(int Id);
        Task<HostelRoom> AddAsync(HostelRoom payload);
        Task<HostelRoom> UpdateAsync(HostelRoom payload);
        Task<HostelRoom> DeleteAsync(int Id);
    }
}
