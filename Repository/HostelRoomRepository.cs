using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class HostelRoomRepository : IHostelRoom
    {
        private readonly AppDbContext _appDbContext;
        public HostelRoomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<HostelRoom>> GetAllAsync(int Id)
        {
            return await _appDbContext.HostelRooms.Where(g=>g.HostelId == Id && g.IsDeleted != true).ToListAsync();
        }
        public async Task<HostelRoom> GetByIdAsync(int Id)
        {
            return await _appDbContext.HostelRooms.FindAsync(Id);
        }
        public async Task<HostelRoom> AddAsync(HostelRoom payload)
        {
            var fetch = await _appDbContext.HostelRooms.Where(b => b.HostelId == payload.HostelId && b.HostelRoomNo == payload.HostelRoomNo).FirstOrDefaultAsync();
            if (fetch == null)
            {
                payload.CreatedAt = DateTime.UtcNow;
                payload.IsDeleted = false;
                _appDbContext.HostelRooms.Add(payload);
                await _appDbContext.SaveChangesAsync();
                return payload;
            }
            return fetch;
        }
        public async Task<HostelRoom> UpdateAsync(HostelRoom payload)
        {
            var fetch = await _appDbContext.HostelRooms.Where(b => b.HostelRoomId == payload.HostelRoomId).FirstOrDefaultAsync();
            if (fetch != null)
            {
                fetch.LastUpdatedAt = DateTime.UtcNow;
                fetch.IsDeleted = false;
                fetch.HostelRoomNo = payload.HostelRoomNo;
                fetch.LastUpdatedBy = payload.LastUpdatedBy;
                _appDbContext.HostelRooms.Update(fetch);
                await _appDbContext.SaveChangesAsync();
                return fetch;
            }
            return payload;
        }
        public async Task<HostelRoom> DeleteAsync(int Id)
        {
            var fetch = await _appDbContext.HostelRooms.FindAsync(Id);
            fetch.IsDeleted = true;
            _appDbContext.HostelRooms.Update(fetch);
            await _appDbContext.SaveChangesAsync();
            return fetch;
        }
    }
}
