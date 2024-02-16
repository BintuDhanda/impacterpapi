using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class IdentityTypeRepository: IIdentityType
    {
        private readonly AppDbContext _appDbContext;
        public IdentityTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<IdentityType>> GetAllAsync()
        {
            return await _appDbContext.IdentityType.ToListAsync();
        }
        public async Task<IdentityType> GetByIdAsync(int Id)
        {
            return await _appDbContext.IdentityType.FindAsync(Id);
        }
        public async Task<IdentityType> AddAsync(IdentityType identityType)
        {
            var identityTypes = await _appDbContext.IdentityType.Where(at => at.Name == identityType.Name).FirstOrDefaultAsync();
            if (identityTypes == null)
            {
                identityType.CreatedAt = DateTime.UtcNow;
                identityType.IsDeleted = false;
                _appDbContext.IdentityType.Add(identityType);
                await _appDbContext.SaveChangesAsync();
                return identityType;
            }
            return identityTypes;
        }
        public async Task<IdentityType> UpdateAsync(IdentityType identityType)
        {
            var isExist = await _appDbContext.IdentityType.Where(at => at.Name == identityType.Name && at.IdentityTypeId != identityType.IdentityTypeId).AnyAsync();
            if (!isExist)
            {
                var identityTypes = await _appDbContext.IdentityType.Where(at => at.IdentityTypeId == identityType.IdentityTypeId).FirstOrDefaultAsync();
                if (identityTypes != null)
                {
                    identityTypes.LastUpdatedAt = DateTime.UtcNow;
                    identityTypes.IsDeleted = false;
                    identityTypes.LastUpdatedBy = identityType.LastUpdatedBy;
                    identityTypes.Name = identityType.Name;
                    _appDbContext.IdentityType.Update(identityTypes);
                    await _appDbContext.SaveChangesAsync();
                    return identityTypes;
                }
            }
            return identityType;
        }
        public async Task<IdentityType> DeleteAsync(int Id)
        {
            var identityType = await _appDbContext.IdentityType.FindAsync(Id);
            _appDbContext.IdentityType.Remove(identityType);
            await _appDbContext.SaveChangesAsync();
            return identityType;
        }
    }
}
