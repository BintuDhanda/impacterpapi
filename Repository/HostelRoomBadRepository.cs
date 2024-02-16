using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class HostelRoomBadRepository : IHostelRoomBad
    {
        private readonly AppDbContext _appDbContext;
        public HostelRoomBadRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<HostelRoomBad>> GetAllAsync(int Id)
        {
            return await _appDbContext.HostelRoomBads.Where(g => g.HostelRoomId == Id && g.IsDeleted != true).ToListAsync();
        }
        public async Task<IEnumerable<HostelRoomBad>> GetAllUnallocatedAsync(int Id)
        {
            return await _appDbContext.HostelRoomBads.Where(g => g.HostelRoomId == Id && g.IsDeleted != true && g.IsAllocated != true).ToListAsync();
        }
        public async Task<HostelRoomBad> GetByIdAsync(int Id)
        {
            return await _appDbContext.HostelRoomBads.FindAsync(Id);
        }
        public async Task<HostelRoomBad> AddAsync(HostelRoomBad payload)
        {
            var fetch = await _appDbContext.HostelRoomBads.Where(b => b.HostelRoomId == payload.HostelRoomId && b.HostelRoomBadNo == payload.HostelRoomBadNo).FirstOrDefaultAsync();
            if (fetch == null)
            {
                payload.CreatedAt = DateTime.UtcNow;
                payload.IsDeleted = false;
                payload.IsAllocated = false;
                _appDbContext.HostelRoomBads.Add(payload);
                await _appDbContext.SaveChangesAsync();
                return payload;
            }
            return fetch;
        }
        public async Task<HostelRoomBad> UpdateAsync(HostelRoomBad payload)
        {
            var isExist = await _appDbContext.HostelRoomBads.Where(b => b.HostelRoomId == payload.HostelRoomId && b.HostelRoomBadNo == payload.HostelRoomBadNo && b.HostelRoomBadId != payload.HostelRoomBadId).AnyAsync();
            if (!isExist)
            {
                var fetch = await _appDbContext.HostelRoomBads.Where(b => b.HostelRoomBadId == payload.HostelRoomBadId).FirstOrDefaultAsync();
                if (fetch != null)
                {
                    fetch.LastUpdatedAt = DateTime.UtcNow;
                    fetch.HostelRoomBadNo = payload.HostelRoomBadNo;
                    fetch.HostelRoomBadSecurity = payload.HostelRoomBadSecurity;
                    fetch.HostelRoomBadAmount = payload.HostelRoomBadAmount;
                    fetch.IsDeleted = false;
                    fetch.LastUpdatedBy = payload.LastUpdatedBy;
                    _appDbContext.HostelRoomBads.Update(fetch);
                    await _appDbContext.SaveChangesAsync();
                    return fetch;
                }
            }
            return payload;
        }
        public async Task<HostelRoomBad> DeleteAsync(int Id)
        {
            var fetch = await _appDbContext.HostelRoomBads.FindAsync(Id);
            fetch.IsDeleted = true;
            _appDbContext.HostelRoomBads.Update(fetch);
            await _appDbContext.SaveChangesAsync();
            return fetch;
        }
    }
}
