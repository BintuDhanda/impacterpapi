using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
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
        public async Task<IEnumerable<Attendance>> GetAllByUserIdAsync(int UserId)
        {
            var attendance = await (from allAttendance in _appDbContext.Attendance
                                    join users in _appDbContext.Users on allAttendance.UserId equals users.Id
                                    where allAttendance.UserId == UserId
                                    select new Attendance
                                    {
                                        Id = allAttendance.Id,
                                        UserId = allAttendance.UserId,
                                        PunchTime = allAttendance.PunchTime,
                                        UserName = users.UserName
                                    }).OrderByDescending(o=>o.Id).ToListAsync();
            return attendance;
        }
        public async Task<Attendance> GetByIdAsync(int Id)
        {
            return await _appDbContext.Attendance.FindAsync(Id);
        }
        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            attendance.PunchTime = System.DateTime.UtcNow;
            _appDbContext.Attendance.Add(attendance);
            await _appDbContext.SaveChangesAsync();
            return attendance;
        }
        public async Task<Attendance> UpdateAsync(Attendance attendance)
        {
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
