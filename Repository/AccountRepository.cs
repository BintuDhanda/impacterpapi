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
            var accounts = await _appDbcontext.Account.Where(a => a.AccountName == account.AccountName).FirstOrDefaultAsync();
            if (accounts == null)
            {
            account.CreatedAt = DateTime.UtcNow;
            account.IsDeleted = false;
            _appDbcontext.Account.Add(account);
            await _appDbcontext.SaveChangesAsync();
            return account;
            }
            return accounts;
        }
        public async Task<Account> UpdateAsync(Account account)
        {
            var accounts = await _appDbcontext.Account.Where(a => a.AccountId == account.AccountId).FirstOrDefaultAsync();
            if (accounts != null)
            {
                accounts.LastUpdatedAt = DateTime.UtcNow;
                accounts.IsDeleted = false;
                accounts.AccountName = account.AccountName;
                accounts.LastUpdatedBy = account.LastUpdatedBy;
                _appDbcontext.Account.Update(accounts);
                await _appDbcontext.SaveChangesAsync();
                return accounts;
            }
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
