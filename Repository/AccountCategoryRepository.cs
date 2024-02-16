using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class AccountCategoryRepository : IAccountCategory
    {
        private readonly AppDbContext _appdbContext;
        public AccountCategoryRepository(AppDbContext appdbContext)
        {
            _appdbContext = appdbContext;
        }
        public async Task<IEnumerable<AccountCategory>> GetAllAsync()
        {
            return await _appdbContext.AccountCategory.ToListAsync();
        }
        public async Task<AccountCategory> GetByIdAsync(int Id)
        {
            return await _appdbContext.AccountCategory.FindAsync(Id);
        }
        public async Task<AccountCategory> AddAsync(AccountCategory accountCategory)
        {
            var accountCategorys = await _appdbContext.AccountCategory.Where(ac => ac.AccCategoryName == accountCategory.AccCategoryName).FirstOrDefaultAsync();
            if (accountCategorys == null)
            {
                accountCategory.CreatedAt = DateTime.UtcNow;
                accountCategory.IsDeleted = false;
                _appdbContext.AccountCategory.Add(accountCategory);
                await _appdbContext.SaveChangesAsync();
                return accountCategory;
            }
            return accountCategorys;
        }
        public async Task<AccountCategory> UpdateAsync(AccountCategory accountCategory)
        {
            var isExist = await _appdbContext.AccountCategory.Where(ac => ac.AccountCategoryId != accountCategory.AccountCategoryId && ac.AccCategoryName == accountCategory.AccCategoryName).AnyAsync();
            if (!isExist)
            {
                var accountCategorys = await _appdbContext.AccountCategory.Where(ac => ac.AccountCategoryId == accountCategory.AccountCategoryId).FirstOrDefaultAsync();
                if (accountCategorys != null)
                {
                    accountCategorys.LastUpdatedAt = DateTime.UtcNow;
                    accountCategorys.IsDeleted = false;
                    accountCategorys.AccCategoryName = accountCategory.AccCategoryName;
                    accountCategorys.LastUpdatedBy = accountCategory.LastUpdatedBy;
                    _appdbContext.AccountCategory.Update(accountCategorys);
                    await _appdbContext.SaveChangesAsync();
                    return accountCategorys;
                }
            }
            return accountCategory;
        }
        public async Task<AccountCategory> DeleteAsync(int Id)
        {
            var accountCategory = await _appdbContext.AccountCategory.FindAsync(Id);
            _appdbContext.AccountCategory.Remove(accountCategory);
            await _appdbContext.SaveChangesAsync();
            return accountCategory;
        }
    }
}
