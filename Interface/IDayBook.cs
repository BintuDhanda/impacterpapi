using ERP.Models;

namespace ERP.Interface
{
    public interface IDayBook
    {
        Task<IEnumerable<DayBook>> GetAllAsync();
        Task <IEnumerable<DayBook>> GetDayBookByAccountIdAsync(int Id);
        Task <DayBook> AddAsync(DayBook dayBook);
        Task <DayBook> UpdateAsync(DayBook dayBook);
        Task <DayBook> DeleteAsync(int Id);
    }
}
