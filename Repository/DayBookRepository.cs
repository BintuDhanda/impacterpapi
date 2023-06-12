using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class DayBookRepository : IDayBook
    {
        private readonly AppDbContext _appDbContext;
        public DayBookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<DayBook>> GetAllAsync(CommonSearchFilter commonSearchFilter)
        {
             var dayBook = await (from allDayBook in _appDbContext.DayBook
                                               join account in _appDbContext.Account on allDayBook.AccountId equals account.Id
                                               where allDayBook.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From) &&
                                                     allDayBook.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To)
                                               select new DayBook
                                               {
                                                   ID = allDayBook.ID,
                                                   Particulars = allDayBook.Particulars,
                                                   Credit = allDayBook.Credit,
                                                   Debit = allDayBook.Debit,
                                                   CreatedAt = allDayBook.CreatedAt,
                                                   AccountId = allDayBook.AccountId,
                                                   IsActive = allDayBook.IsActive,
                                                   Account = account.AccountName,
                                               })
                         .OrderByDescending(o => o.ID)
                         .Skip(commonSearchFilter.Skip)
                         .Take(commonSearchFilter.Take)
                         .ToListAsync();
            return dayBook;
        }
        public async Task<IEnumerable<DayBook>> GetDayBookByAccountIdAsync(int Id)
        {
            var dayBook = await (from allDayBook in _appDbContext.DayBook
                                 join account in _appDbContext.Account on allDayBook.AccountId equals account.Id
                                 select new DayBook
                                 {
                                     ID = allDayBook.ID,
                                     Particulars = allDayBook.Particulars,
                                     Credit = allDayBook.Credit,
                                     Debit = allDayBook.Debit,
                                     CreatedAt = allDayBook.CreatedAt,
                                     AccountId = allDayBook.AccountId,
                                     IsActive = allDayBook.IsActive,
                                     Account = account.AccountName,
                                 }).Where(d => d.AccountId == Id).ToListAsync();
            return dayBook;
        }
        public async Task<DayBook> AddAsync(DayBook dayBook)
        {
            
                dayBook.CreatedAt = System.DateTime.UtcNow;
                if(dayBook.AccountId != 0 && dayBook.Credit != 0 || dayBook.Debit != 0)
                {
                    _appDbContext.DayBook.Add(dayBook);
                    await _appDbContext.SaveChangesAsync();
                }
            return dayBook;
        }
        public async Task<DayBook> UpdateAsync(DayBook dayBook)
        {
            _appDbContext.DayBook.Update(dayBook);
            await _appDbContext.SaveChangesAsync();
            return dayBook;
        }
        public async Task<DayBook> DeleteAsync(int Id)
        {
            var daybook = await _appDbContext.DayBook.FindAsync(Id);
            _appDbContext.DayBook.Remove(daybook);
            await _appDbContext.SaveChangesAsync();
            return daybook;
        }
    }
}
