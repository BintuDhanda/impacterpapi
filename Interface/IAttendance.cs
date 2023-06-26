using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface IAttendance
    {
        Task<IEnumerable<Attendance>> GetAttendanceByRegistrationNumberAsync(AttendanceSearch attendanceSearch);
        Task<Attendance> GetByIdAsync(int Id);
        Task<Attendance> AddAsync(Attendance attendance);
        Task<Attendance> UpdateAsync(Attendance attendance);
        Task<Attendance> DeleteAsync(int Id);
        Task<IActionResult> RegistrationIsExist(AttendanceSearch attendanceSearch);
    }
}
