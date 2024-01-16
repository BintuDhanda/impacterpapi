using ERP.Models;

namespace ERP.Interface
{
    public interface IHostelRoomBadStudentRent
    {
        Task<IEnumerable<HostelRoomBadStudentRent>> GetAllAsync();
        Task<HostelRoomBadStudentRent> GetByIdAsync(int Id);
        Task<HostelRoomBadStudentRent> AddAsync(HostelRoomBadStudentRent payload);
        Task<HostelRoomBadStudentRent> UpdateAsync(HostelRoomBadStudentRent payload);
        Task<HostelRoomBadStudentRent> DeleteAsync(int Id);
    }
}
