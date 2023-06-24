using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class AttendanceRepository:IAttendance
    {
        private readonly AppDbContext _appDbContext;
        public AttendanceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync(int StudentId, CommonSearchFilter commonSearchFilter)
        {
            var attendance = await (from allAttendance in _appDbContext.Attendance
                                 where allAttendance.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From) &&
                                       allAttendance.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To)
                                 select new Attendance
                                 {
                                     Id = allAttendance.Id,
                                     BatchId = allAttendance.BatchId,
                                     StudentId = allAttendance.StudentId,
                                     AttendanceType = allAttendance.AttendanceType,
                                     PunchTime = allAttendance.PunchTime,
                                     RegisterationNumber = allAttendance.RegisterationNumber,
                                     IsActive = allAttendance.IsActive,
                                     IsDeleted = allAttendance.IsDeleted,
                                     CreatedAt = allAttendance.CreatedAt,
                                     CreatedBy = allAttendance.CreatedBy,
                                     UpdatedAt = allAttendance.UpdatedAt,
                                     UpdatedBy = allAttendance.UpdatedBy,
                                     BatchName = _appDbContext.Batch.Where(b=>b.Id == allAttendance.BatchId).Select(b=>b.BatchName).FirstOrDefault()
                                 })
                        .Where(a=>a.StudentId == StudentId)
                        .OrderByDescending(o => o.Id)
                        .Skip(commonSearchFilter.Skip)
                        .Take(commonSearchFilter.Take)
                        .ToListAsync();
            return attendance;
        }
        public async Task<Attendance> GetByIdAsync(int Id)
        {
            return await _appDbContext.Attendance.FindAsync(Id);
        }
        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            attendance.PunchTime = System.DateTime.UtcNow;
            attendance.CreatedAt = System.DateTime.UtcNow;
            attendance.IsDeleted = false;
            _appDbContext.Attendance.Add(attendance);
            await _appDbContext.SaveChangesAsync();
            return attendance;
        }
        public async Task<Attendance> UpdateAsync(Attendance attendance)
        {
            attendance.UpdatedAt = System.DateTime.UtcNow;
            attendance.IsDeleted = false;
            _appDbContext.Attendance.Update(attendance);
            await _appDbContext.SaveChangesAsync();
            return attendance;
        }
        public async Task<Attendance> DeleteAsync(int Id)
        {
            var attendance = await _appDbContext.Attendance.FindAsync(Id);
            _appDbContext.Attendance.Remove(attendance);
            await _appDbContext.SaveChangesAsync();
            return attendance;
        }
    }
}
