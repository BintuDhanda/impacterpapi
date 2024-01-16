using ERP.Models;

namespace ERP.Interface
{
    public interface IHostel
    {
        Task<IEnumerable<Hostel>> GetAllAsync();
        Task<Hostel> GetByIdAsync(int Id);
        Task<Hostel> AddAsync(Hostel hostel);
        Task<Hostel> UpdateAsync(Hostel hostel);
        Task<Hostel> DeleteAsync(int Id);
    }
}
