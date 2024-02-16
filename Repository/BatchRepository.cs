using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class BatchRepository : IBatch
    {
        private readonly AppDbContext _appDbContext;
        public BatchRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Batch>> GetAllAsync()
        {
            return await _appDbContext.Batch.ToListAsync();
        }
        public async Task<Batch> GetByIdAsync(int Id)
        {
            return await _appDbContext.Batch.FindAsync(Id);
        }
        public async Task<Batch> AddAsync(Batch batch)
        {
            var batchs = await _appDbContext.Batch.Where(b => b.BatchName == batch.BatchName).FirstOrDefaultAsync();
            if (batchs == null)
            {
                batch.CreatedAt = DateTime.UtcNow;
                batch.IsDeleted = false;
                _appDbContext.Batch.Add(batch);
                await _appDbContext.SaveChangesAsync();
                return batch;
            }
            return batchs;
        }
        public async Task<Batch> UpdateAsync(Batch batch)
        {
            var isExist = await _appDbContext.Batch.Where(b => b.BatchName == batch.BatchName && b.BatchId != batch.BatchId).AnyAsync();
            if (!isExist)
            {
                var batchs = await _appDbContext.Batch.Where(b => b.BatchId == batch.BatchId).FirstOrDefaultAsync();
                if (batchs != null)
                {
                    batchs.LastUpdatedAt = DateTime.UtcNow;
                    batchs.IsDeleted = false;
                    batchs.BatchName = batch.BatchName;
                    batchs.StartDate = batch.StartDate;
                    batchs.EndDate = batch.EndDate;
                    batchs.Code = batch.Code;
                    batchs.CourseId = batch.CourseId;
                    batchs.LastUpdatedBy = batch.LastUpdatedBy;
                    _appDbContext.Batch.Update(batchs);
                    await _appDbContext.SaveChangesAsync();
                    return batchs;
                }
            }
            return batch;
        }
        public async Task<Batch> DeleteAsync(int Id)
        {
            var batch = await _appDbContext.Batch.FindAsync(Id);
            _appDbContext.Batch.Remove(batch);
            await _appDbContext.SaveChangesAsync();
            return batch;
        }
        public async Task<IEnumerable<Batch>> GetBatchByCourseIdAsync(int Id)
        {
            return await _appDbContext.Batch.Where(b => b.CourseId == Id).Select(s => new Batch
            {
                BatchId = s.BatchId,
                BatchName = s.BatchName,
                Code = s.Code,
                CourseId = s.CourseId,
                StartDate = TimeZoneConvert.UtcToIST(s.StartDate),
                EndDate = TimeZoneConvert.UtcToIST(s.EndDate),
                IsActive = s.IsActive,
                IsDeleted = s.IsDeleted,
                CreatedAt = s.CreatedAt,
                CreatedBy = s.CreatedBy,
                LastUpdatedAt = s.LastUpdatedAt,
                LastUpdatedBy = s.LastUpdatedBy,
                Duration = ((s.EndDate - s.StartDate).Days).ToString() + " Days",
            }).ToListAsync();
        }
    }
}
