using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;
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
                                               where allDayBook.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From)&&
                                                     allDayBook.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To)
                                               select new DayBook
                                               {
                                                   DayBookId = allDayBook.DayBookId,
                                                   Particulars = allDayBook.Particulars,
                                                   Credit = allDayBook.Credit,
                                                   Debit = allDayBook.Debit,
                                                   CreatedAt = allDayBook.CreatedAt,
                                                   AccountId = allDayBook.AccountId,
                                                   IsActive = allDayBook.IsActive,
                                                   Account = _appDbContext.Account.Where(w=>w.AccountId== allDayBook.AccountId).Select(s=>s.AccountName).FirstOrDefault(),
                                               })
                         .OrderByDescending(o => o.DayBookId)
                         .Skip(commonSearchFilter.Skip)
                         .Take(commonSearchFilter.Take)
                         .ToListAsync();
            return dayBook;
        }
        public async Task<IEnumerable<DayBook>> GetDayBookByAccountIdAsync(AccountSearchFilter accountSearchFilter)
        {
            var dayBook = await _appDbContext.DayBook
                                 .Where(d => d.AccountId == accountSearchFilter.AccountId && (d.CreatedAt >= Convert.ToDateTime(accountSearchFilter.From).ToUniversalTime() &&
                         d.CreatedAt <= Convert.ToDateTime(accountSearchFilter.To).ToUniversalTime()))
                                 .Select(d => new DayBook
                                 {
                                     DayBookId = d.DayBookId,
                                     Particulars = d.Particulars,
                                     Credit = d.Credit,
                                     Debit = d.Debit,
                                     CreatedAt = d.CreatedAt,
                                     AccountId = d.AccountId,
                                     IsActive = d.IsActive,
                                     Account = _appDbContext.Account.Where(w => w.AccountId == d.AccountId).Select(s => s.AccountName).FirstOrDefault(),
                                 })
                                 .OrderByDescending(o => o.DayBookId)
                                 .Skip(accountSearchFilter.Skip)
                                 .Take(accountSearchFilter.Take)
                                 .ToListAsync();
            return dayBook;
        }
        public async Task<DayBook> AddAsync(DayBook dayBook)
        {
            
                dayBook.CreatedAt = System.DateTime.UtcNow;
                dayBook.IsDeleted = false;
                if(dayBook.AccountId != 0 && dayBook.Credit != 0 || dayBook.Debit != 0)
                {
                    _appDbContext.DayBook.Add(dayBook);
                    await _appDbContext.SaveChangesAsync();
                }
            return dayBook;
        }
        public async Task<DayBook> UpdateAsync(DayBook dayBook)
        {
            dayBook.UpdatedAt = System.DateTime.UtcNow;
            dayBook.IsDeleted = false;
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
        public async Task<IActionResult> SumCreditAndDebitAsync(SumCreditAndDebitAcountDaybook sumCreditAndDebitAccountDaybook)
        {
            var Credit = await _appDbContext.DayBook.Where(d => d.AccountId == sumCreditAndDebitAccountDaybook.AccountId && (d.CreatedAt >= Convert.ToDateTime(sumCreditAndDebitAccountDaybook.From).ToUniversalTime() &&
                         d.CreatedAt <= Convert.ToDateTime(sumCreditAndDebitAccountDaybook.To).ToUniversalTime())).SumAsync(s => s.Credit);
            var Debit = await _appDbContext.DayBook.Where(r => r.AccountId == sumCreditAndDebitAccountDaybook.AccountId && (r.CreatedAt >= Convert.ToDateTime(sumCreditAndDebitAccountDaybook.From).ToUniversalTime() &&
                         r.CreatedAt <= Convert.ToDateTime(sumCreditAndDebitAccountDaybook.To).ToUniversalTime())).SumAsync(s => s.Debit);
            var Result = new { Credit, Debit };

            return new JsonResult(Result);
        }
        public async Task<IActionResult> SumCreditAndDebitDayBookAsync(SumCreditAndDebitDayBook sumCreditAndDebitDayBook)
        {
            var Credit = await _appDbContext.DayBook.Where(d =>  d.CreatedAt >= Convert.ToDateTime(sumCreditAndDebitDayBook.From).ToUniversalTime() &&
                         d.CreatedAt <= Convert.ToDateTime(sumCreditAndDebitDayBook.To).ToUniversalTime()).SumAsync(s => s.Credit);
            var Debit = await _appDbContext.DayBook.Where(r => r.CreatedAt >= Convert.ToDateTime(sumCreditAndDebitDayBook.From).ToUniversalTime() &&
                         r.CreatedAt <= Convert.ToDateTime(sumCreditAndDebitDayBook.To).ToUniversalTime()).SumAsync(s => s.Debit);
            var Result = new { Credit, Debit };

            return new JsonResult(Result);
        }
    }
}
