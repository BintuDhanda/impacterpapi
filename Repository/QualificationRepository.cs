using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class QualificationRepository:IQualification
    {
        private readonly AppDbContext _appDbContext;
        public QualificationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Qualification>> GetAllAsync()
        {
            return await _appDbContext.Qualification.ToListAsync();
        }
        public async Task<Qualification> GetByIdAsync(int Id)
        {
            return await _appDbContext.Qualification.FindAsync(Id);
        }
        public async Task<Qualification> AddAsync(Qualification qualification)
        {
            qualification.CreatedAt = DateTime.UtcNow;
            qualification.IsDeleted = false;
            _appDbContext.Qualification.Add(qualification);
            await _appDbContext.SaveChangesAsync();
            return qualification;
        }
        public async Task<Qualification> UpdateAsync(Qualification qualification)
        {
            qualification.LastUpdatedAt = DateTime.UtcNow;
            qualification.IsDeleted = false;
            _appDbContext.Qualification.Update(qualification);
            await _appDbContext.SaveChangesAsync();
            return qualification;
        }
        public async Task<Qualification> DeleteAsync(int Id)
        {
            var qualification = await _appDbContext.Qualification.FindAsync(Id);
            _appDbContext.Remove(qualification);
            await _appDbContext.SaveChangesAsync();
            return qualification;
        }
    }
}
