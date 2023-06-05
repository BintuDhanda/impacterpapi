using ERP.Models;

namespace ERP.Interface
{
    public interface IAttendance
    {
        Task<IEnumerable<Attendance>> GetAllByUserIdAsync(int UserId);
        Task<Attendance> GetByIdAsync(int Id);
        Task<Attendance> AddAsync(Attendance attendance);
        Task<Attendance> UpdateAsync(Attendance attendance);
        Task<Attendance> DeleteAsync(int Id);
    }
}
