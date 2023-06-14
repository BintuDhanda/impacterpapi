using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class BatchRepository:IBatch
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
            batch.CreatedAt = DateTime.UtcNow;
            batch.IsDeleted = false;
            _appDbContext.Batch.Add(batch);
            await _appDbContext.SaveChangesAsync();
            return batch;
        }
        public async Task<Batch> UpdateAsync(Batch batch)
        {
            _appDbContext.Batch.Update(batch);
            await _appDbContext.SaveChangesAsync();
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
            return await _appDbContext.Batch.Where(b => b.CourseId == Id).ToListAsync();
        }
    }
}
