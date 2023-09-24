using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class StudentIdentitiesRepository: IStudentIdentities
    {
        private readonly AppDbContext _appDbContext;
        public StudentIdentitiesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<StudentIdentities>> GetStudentIdentitiesByStudentBatchId(int Id)
        {
            var studentIdentities = await _appDbContext.StudentIdentities.Select( si => new StudentIdentities
            {
                StudentIdentitiesId = si.StudentIdentitiesId,
                StudentBatchId = si.StudentBatchId,
                IdentityTypeId = si.IdentityTypeId,
                Status = si.Status,
                StringStatus = si.Status == true?"Active":"In-Active",
                StudentBatchName = _appDbContext.Batch.Where(b => b.BatchId == (_appDbContext.StudentBatch.Where(sb => sb.StudentBatchId == si.StudentBatchId).Select(s => s.BatchId).FirstOrDefault())).Select(s=> s.BatchName).FirstOrDefault(),
                IdentityTypeName = _appDbContext.IdentityType.Where(it => it.IdentityTypeId == si.IdentityTypeId).Select(i => i.Name).FirstOrDefault(),
                IsActive = si.IsActive,
                IsDeleted = si.IsDeleted,
                CreatedAt = TimeZoneConvert.UtcToIST(si.CreatedAt),
                CreatedBy = si.CreatedBy,
                LastUpdatedAt = si.LastUpdatedAt,
                LastUpdatedBy = si.LastUpdatedBy,
            }).Where(s => s.StudentBatchId == Id).ToListAsync();
            return studentIdentities;
        }
        public async Task<StudentIdentities> GetByIdAsync(int Id)
        {
            var studentIdentities = await _appDbContext.StudentIdentities.Select(si => new StudentIdentities
            {
                StudentIdentitiesId = si.StudentIdentitiesId,
                StudentBatchId = si.StudentBatchId,
                IdentityTypeId = si.IdentityTypeId,
                Status = si.Status,
                StringStatus = si.Status == true ? "Active" : "In-Active",
                IsActive = si.IsActive,
                IsDeleted = si.IsDeleted,
                CreatedAt = si.CreatedAt,
                CreatedBy = si.CreatedBy,
                LastUpdatedAt = si.LastUpdatedAt,
                LastUpdatedBy = si.LastUpdatedBy,
            }).Where(s => s.StudentIdentitiesId == Id).FirstOrDefaultAsync();
            return studentIdentities;
        }
        public async Task<StudentIdentities> AddAsync(StudentIdentities studentIdentities)
        {
                var studentIdentite = _appDbContext.StudentIdentities.Where(sdi => sdi.IdentityTypeId ==  studentIdentities.IdentityTypeId && sdi.StudentBatchId == studentIdentities.StudentBatchId).FirstOrDefault();
            if (studentIdentite == null)
            {
                studentIdentities.Status = studentIdentities.StringStatus == "Active" ? true : false;
                studentIdentities.CreatedAt = DateTime.UtcNow;
                studentIdentities.IsDeleted = false;
                _appDbContext.StudentIdentities.Add(studentIdentities);
                await _appDbContext.SaveChangesAsync();
                return studentIdentities;
            }
            return studentIdentite;
        }
        public async Task<StudentIdentities> UpdateAsync(StudentIdentities studentIdentities)
        {
            var studentIdentite = _appDbContext.StudentIdentities.Where(sdi => sdi.IdentityTypeId == studentIdentities.IdentityTypeId && sdi.StudentBatchId == studentIdentities.StudentBatchId).FirstOrDefault();
            if (studentIdentite == null)
            {
                studentIdentities.Status = studentIdentities.StringStatus == "Active" ? true : false;
                studentIdentities.LastUpdatedAt = DateTime.UtcNow;
                studentIdentities.IsDeleted = false;
                studentIdentities.LastUpdatedBy = studentIdentities.LastUpdatedBy;
                _appDbContext.StudentIdentities.Update(studentIdentities);
                await _appDbContext.SaveChangesAsync();
                return studentIdentities;
            }
            return studentIdentite;
        }
        public async Task<StudentIdentities> DeleteAsync(int Id)
        {
            var studentIdentities = await _appDbContext.StudentIdentities.FindAsync(Id);
            _appDbContext.StudentIdentities.Remove(studentIdentities);
            await _appDbContext.SaveChangesAsync();
            return studentIdentities;
        }
    }
}
