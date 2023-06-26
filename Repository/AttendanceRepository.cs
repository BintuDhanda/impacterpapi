using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Attendance>> GetAttendanceByRegistrationNumberAsync(AttendanceSearch attendanceSearch)
        {
            var attendance = await _appDbContext.Attendance
                        .Where(a => a.StudentBatchId == _appDbContext.StudentBatch.Where(w=>w.RegistrationNumber==(attendanceSearch.RegistrationNumber)).Select(s=>s.StudentBatchId).FirstOrDefault())
                        .Select(s => new Attendance
                        {
                            AttendanceId = s.AttendanceId,
                            StudentBatchId = s.StudentBatchId,
                            StudentId = s.StudentId,
                            AttendanceType = s.AttendanceType,
                            PunchTime = s.PunchTime,
                            RegistrationNumber = _appDbContext.StudentBatch.Where(w=>w.RegistrationNumber == attendanceSearch.RegistrationNumber).Select(s=>s.RegistrationNumber).FirstOrDefault(),
                            IsActive = s.IsActive,
                            IsDeleted = s.IsDeleted,
                            CreatedAt = s.CreatedAt,
                            CreatedBy = s.CreatedBy,
                            UpdatedAt = s.UpdatedAt,
                            UpdatedBy = s.UpdatedBy,
                            BatchName = _appDbContext.Batch.Where(b => b.Id == (_appDbContext.StudentBatch.Where(sb => sb.StudentBatchId == s.StudentBatchId).Select(b => b.BatchId).FirstOrDefault())).Select(x=>x.BatchName).FirstOrDefault(),
                            StudentName = _appDbContext.StudentDetails.Where(sd => sd.Id == s.StudentId).Select(s=>s.FirstName + " " + s.LastName).FirstOrDefault(),
                            Mobile = _appDbContext.Users.Where(u => u.Id == (_appDbContext.StudentDetails.Where(sd => sd.Id == s.StudentId).Select(s => s.UserId).FirstOrDefault())).Select(u=>u.UserMobile).FirstOrDefault(),
                        })
                        .OrderByDescending(o => o.AttendanceId)
                        .Skip(attendanceSearch.Skip)
                        .Take(attendanceSearch.Take)
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
            attendance.StudentId = _appDbContext.StudentBatch.Where(b => b.RegistrationNumber == attendance.RegistrationNumber).Select(b => b.StudentId).FirstOrDefault();
            attendance.StudentBatchId = _appDbContext.StudentBatch.Where(_b => _b.RegistrationNumber == attendance.RegistrationNumber).Select(_b => _b.StudentBatchId).FirstOrDefault();
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
        public async Task<IActionResult> RegistrationIsExist(AttendanceSearch attendanceSearch)
        {
            return new JsonResult(await _appDbContext.StudentBatch.AnyAsync(x => x.RegistrationNumber == attendanceSearch.RegistrationNumber));
        }
    }
}
