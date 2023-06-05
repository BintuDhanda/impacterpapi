using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class FeeTypeRepository:IFeeType
    {
        private readonly AppDbContext _appdbContext;
        public FeeTypeRepository(AppDbContext appdbContext)
        {
            _appdbContext = appdbContext;
        }
        public async Task<IEnumerable<FeeType>> GetAllAsync()
        {
            return await _appdbContext.FeeType.ToListAsync();
        }
        public async Task<FeeType> GetByIdAsync(int Id)
        {
            return await _appdbContext.FeeType.FindAsync(Id);
        }
        public async Task<FeeType> AddAsync(FeeType feeType)
        {
            _appdbContext.FeeType.Add(feeType);
            await _appdbContext.SaveChangesAsync();
            return feeType;
        }
        public async Task<FeeType> UpdateAsync(FeeType feeType)
        {
            _appdbContext.FeeType.Update(feeType);
            await _appdbContext.SaveChangesAsync();
            return feeType;
        }
        public async Task<FeeType> DeleteAsync(int Id)
        {
            var feeType = await _appdbContext.FeeType.FindAsync(Id);
            _appdbContext.FeeType.Remove(feeType);
            await _appdbContext.SaveChangesAsync();
            return feeType;
        }
    }
}
