using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface IDayBook
    {
        Task<IEnumerable<DayBook>> GetAllAsync(CommonSearchFilter commonSearchFilter);
        Task <IEnumerable<DayBook>> GetDayBookByAccountIdAsync(AccountSearchFilter accountSearchFilter);
        Task <DayBook> AddAsync(DayBook dayBook);
        Task <DayBook> UpdateAsync(DayBook dayBook);
        Task <DayBook> DeleteAsync(int Id);
        Task<IActionResult> SumCreditAndDebitAsync(SumCreditAndDebitDaybook sumCreditAndDebitDaybook);
    }
}
