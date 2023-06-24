using ERP.Models;
using ERP.SearchFilters;

namespace ERP.Interface
{
    public interface IAttendance
    {
        Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync(int StudentId, CommonSearchFilter commonSearchFilter);
        Task<Attendance> GetByIdAsync(int Id);
        Task<Attendance> AddAsync(Attendance attendance);
        Task<Attendance> UpdateAsync(Attendance attendance);
        Task<Attendance> DeleteAsync(int Id);
    }
}
