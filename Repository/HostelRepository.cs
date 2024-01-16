using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class HostelRepository : IHostel
    {
        private readonly AppDbContext _appDbContext;
        public HostelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Hostel>> GetAllAsync()
        {
            return await _appDbContext.Hostels.Where(g=>g.IsDeleted != true).ToListAsync();
        }
        public async Task<Hostel> GetByIdAsync(int Id)
        {
            return await _appDbContext.Hostels.FindAsync(Id);
        }
        public async Task<Hostel> AddAsync(Hostel payload)
        {
            var fetch = await _appDbContext.Hostels.Where(b => b.HostelName == payload.HostelName).FirstOrDefaultAsync();
            if (fetch == null)
            {
                payload.CreatedAt = DateTime.UtcNow;
                payload.IsDeleted = false;
                _appDbContext.Hostels.Add(payload);
                await _appDbContext.SaveChangesAsync();
                return payload;
            }
            return fetch;
        }
        public async Task<Hostel> UpdateAsync(Hostel payload)
        {
            var fetch = await _appDbContext.Hostels.Where(b => b.HostelId == payload.HostelId).FirstOrDefaultAsync();
            if (fetch != null)
            {
                fetch.LastUpdatedAt = DateTime.UtcNow;
                fetch.IsDeleted = false;
                fetch.HostelName = payload.HostelName;
                fetch.LastUpdatedBy = payload.LastUpdatedBy;
                _appDbContext.Hostels.Update(fetch);
                await _appDbContext.SaveChangesAsync();
                return fetch;
            }
            return payload;
        }
        public async Task<Hostel> DeleteAsync(int Id)
        {
            var fetch = await _appDbContext.Hostels.FindAsync(Id);
            _appDbContext.Hostels.Remove(fetch);
            await _appDbContext.SaveChangesAsync();
            return fetch;
        }
    }
}
