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
        public async Task <AccountCategory> AddAsync(AccountCategory accountCategory)
        {
            accountCategory.CreatedAt = DateTime.UtcNow;
            accountCategory.IsDeleted = false;
            _appdbContext.AccountCategory.Add(accountCategory);
            await _appdbContext.SaveChangesAsync();
            return accountCategory;
        }
        public async Task <AccountCategory> UpdateAsync(AccountCategory accountCategory)
        {
            accountCategory.UpdatedAt = DateTime.UtcNow;
            accountCategory.IsDeleted = false;
            _appdbContext.AccountCategory.Update(accountCategory);
            await _appdbContext.SaveChangesAsync();
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
