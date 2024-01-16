using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class HostelRoomBadStudentRepository : IHostelRoomBadStudent
    {
        private readonly AppDbContext _appDbContext;
        public HostelRoomBadStudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<HostelRoomBadStudent>> GetAllAsync()
        {
            return await (from sh in _appDbContext.HostelRoomBadStudents
                          join hrb in _appDbContext.HostelRoomBads
                          on sh.HostelRoomBadId equals hrb.HostelRoomBadId
                          join hr in _appDbContext.HostelRooms
                          on hrb.HostelRoomId equals hr.HostelRoomId
                          join h in _appDbContext.Hostels
                          on hr.HostelId equals h.HostelId
                          where hrb.IsAllocated == true && sh.IsDeleted != true
                          select new HostelRoomBadStudent
                          {
                              HostelRoomBadStudentId = sh.HostelRoomBadStudentId,
                              HostelRoomBadId = sh.HostelRoomBadId,
                              StudentId = sh.StudentId,
                              HostelRoomBad = h.HostelName + "/" + hr.HostelRoomNo + "/" + hrb.HostelRoomBadNo
                          }).ToListAsync();
        }
        public async Task<HostelRoomBadStudent> GetByIdAsync(int Id)
        {
            return await _appDbContext.HostelRoomBadStudents.FindAsync(Id);
        }
        public async Task<HostelRoomBadStudent> AddAsync(HostelRoomBadStudent payload)
        {
            var fetch = await _appDbContext.HostelRoomBadStudents.Where(b => b.HostelRoomBadId == payload.HostelRoomBadId && b.IsActive == true).FirstOrDefaultAsync();
            if (fetch == null)
            {
                payload.CreatedAt = DateTime.UtcNow;
                payload.IsDeleted = false;

                var newBad = await _appDbContext.HostelRoomBads.FindAsync(payload.HostelRoomBadId);
                if (newBad != null)
                {
                    newBad.IsAllocated = true;
                    _appDbContext.HostelRoomBads.Update(newBad);
                }
                await _appDbContext.SaveChangesAsync();
                _appDbContext.HostelRoomBadStudents.Add(payload);
                await _appDbContext.SaveChangesAsync();
                return payload;
            }
            return fetch;
        }
        public async Task<HostelRoomBadStudent> UpdateAsync(HostelRoomBadStudent payload)
        {
            var fetch = await _appDbContext.HostelRoomBadStudents.Where(b => b.HostelRoomBadStudentId == payload.HostelRoomBadStudentId).FirstOrDefaultAsync();
            if (fetch != null)
            {
                if (fetch.HostelRoomBadId != payload.HostelRoomBadId)
                {
                    var previousBad = await _appDbContext.HostelRoomBads.FindAsync(fetch.HostelRoomBadId);
                    if (previousBad != null)
                    {
                        previousBad.IsAllocated = false;
                        _appDbContext.HostelRoomBads.Update(previousBad);
                    }
                    var newBad = await _appDbContext.HostelRoomBads.FindAsync(payload.HostelRoomBadId);
                    if (newBad != null)
                    {
                        newBad.IsAllocated = true;
                        _appDbContext.HostelRoomBads.Update(newBad);
                    }
                    await _appDbContext.SaveChangesAsync();
                }
                fetch.StudentId = payload.StudentId;
                fetch.HostelId = payload.HostelId;
                fetch.HostelRoomId = payload.HostelRoomId;
                fetch.HostelRoomBadId = payload.HostelRoomBadId;
                fetch.LastUpdatedAt = DateTime.UtcNow;
                fetch.IsDeleted = false;
                fetch.LastUpdatedBy = payload.LastUpdatedBy;
                _appDbContext.HostelRoomBadStudents.Update(fetch);
                await _appDbContext.SaveChangesAsync();
                return fetch;
            }
            return payload;
        }
        public async Task<HostelRoomBadStudent> DeleteAsync(int Id)
        {
            var fetch = await _appDbContext.HostelRoomBadStudents.FindAsync(Id);
            var previousBad = await _appDbContext.HostelRoomBads.FindAsync(fetch.HostelRoomBadId);
            if (previousBad != null)
            {
                previousBad.IsAllocated = false;
                _appDbContext.HostelRoomBads.Update(previousBad);
            }
            fetch.IsDeleted = true;
            _appDbContext.HostelRoomBadStudents.Update(fetch);
            await _appDbContext.SaveChangesAsync();
            return fetch;
        }
    }
}
