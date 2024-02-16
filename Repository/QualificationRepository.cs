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
            var qualifications = await _appDbContext.Qualification.Where(q => q.QualificationName == qualification.QualificationName).FirstOrDefaultAsync();
            if (qualifications == null)
            {
            qualification.CreatedAt = DateTime.UtcNow;
            qualification.IsDeleted = false;
            _appDbContext.Qualification.Add(qualification);
            await _appDbContext.SaveChangesAsync();
            return qualification;
            }
            return qualifications;
        }
        public async Task<Qualification> UpdateAsync(Qualification qualification)
        {
            var isExist = await _appDbContext.Qualification.Where(q => q.QualificationName == qualification.QualificationName && q.QualificationId != qualification.QualificationId).AnyAsync();
            if (!isExist)
            {
                var qualifications = await _appDbContext.Qualification.Where(q => q.QualificationId == qualification.QualificationId).FirstOrDefaultAsync();
                if (qualifications != null)
                {
                    qualifications.LastUpdatedAt = DateTime.UtcNow;
                    qualifications.IsDeleted = false;
                    qualifications.QualificationName = qualification.QualificationName;
                    qualifications.LastUpdatedBy = qualification.LastUpdatedBy;
                    _appDbContext.Qualification.Update(qualifications);
                    await _appDbContext.SaveChangesAsync();
                    return qualifications;
                }
            }
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
