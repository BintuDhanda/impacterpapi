using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class HostelRoomBadStudentRentRepository : IHostelRoomBadStudentRent
    {
        private readonly AppDbContext _appDbContext;
        public HostelRoomBadStudentRentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<HostelRoomBadStudentRent>> GetAllAsync(int Id)
        {
            return await _appDbContext.HostelRoomBadStudentRents.Where(g => g.IsDeleted != true && g.HostelRoomBadStudentId == Id).ToListAsync();
        }
        public async Task<HostelRoomBadStudentRent> GetByIdAsync(int Id)
        {
            return await _appDbContext.HostelRoomBadStudentRents.FindAsync(Id);
        }
        public async Task<HostelRoomBadStudentRent> AddAsync(HostelRoomBadStudentRent payload)
        {
            try
            {
                payload.Year = DateTime.UtcNow.Year;
                payload.CreatedAt = DateTime.UtcNow;
                payload.IsDeleted = false;

                await _appDbContext.SaveChangesAsync();
                _appDbContext.HostelRoomBadStudentRents.Add(payload);
                await _appDbContext.SaveChangesAsync();
                return payload;
            }
            catch (Exception ex)
            {
                return payload;
            }
        }
        public async Task<HostelRoomBadStudentRent> UpdateAsync(HostelRoomBadStudentRent payload)
        {
            var fetch = await _appDbContext.HostelRoomBadStudentRents.Where(b => b.HostelRoomBadStudentRentId == payload.HostelRoomBadStudentRentId).FirstOrDefaultAsync();
            if (fetch != null)
            {
                fetch.HostelRoomBadStudentId = payload.HostelRoomBadStudentId;
                fetch.Month = payload.Month;
                fetch.Year = payload.Year;
                fetch.ReceivedAmount = payload.ReceivedAmount;
                fetch.RefundAmount = payload.RefundAmount;
                fetch.PaymentType = payload.PaymentType;
                fetch.PaymentMode = payload.PaymentMode;
                fetch.PaymentDate = payload.PaymentDate;
                fetch.Remarks = payload.Remarks;
                fetch.LastUpdatedAt = DateTime.UtcNow;
                fetch.IsDeleted = false;
                fetch.LastUpdatedBy = payload.LastUpdatedBy;
                _appDbContext.HostelRoomBadStudentRents.Update(fetch);
                await _appDbContext.SaveChangesAsync();
                return fetch;
            }
            return payload;
        }
        public async Task<HostelRoomBadStudentRent> DeleteAsync(int Id)
        {
            var fetch = await _appDbContext.HostelRoomBadStudentRents.FindAsync(Id);
            fetch.IsDeleted = true;
            _appDbContext.HostelRoomBadStudentRents.Update(fetch);
            await _appDbContext.SaveChangesAsync();
            return fetch;
        }
    }
}
