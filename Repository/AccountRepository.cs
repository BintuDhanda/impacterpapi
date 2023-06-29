using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class AccountRepository : IAccount
    {
        private readonly AppDbContext _appDbcontext;
        public AccountRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _appDbcontext.Account.ToListAsync();
        }
        public async Task<Account> GetByIdAsync(int Id)
        {
            return await _appDbcontext.Account.FindAsync(Id);
        }
        public async Task <Account> AddAsync(Account account)
        {
            account.CreatedAt = DateTime.UtcNow;
            account.IsDeleted = false;
            _appDbcontext.Account.Add(account);
            await _appDbcontext.SaveChangesAsync();
            return account;
        }
        public async Task<Account> UpdateAsync(Account account)
        {
            account.UpdatedAt = DateTime.UtcNow;
            account.IsDeleted = false;
            _appDbcontext.Account.Update(account);
            await _appDbcontext.SaveChangesAsync();
            return account;
        }
        public async Task<Account> DeleteAsync(int Id)
        {
            var account = await _appDbcontext.Account.FindAsync(Id);
            _appDbcontext.Account.Remove(account);
            await _appDbcontext.SaveChangesAsync();
            return account;
        }
        public async Task<IEnumerable<Account>> GetAccountByAccountCategoryIdAsync(int Id)
        {
            return await _appDbcontext.Account.Where(a=>a.AccCategoryId == Id).ToListAsync();
        }
    }
}
