using ERP.Models;

namespace ERP.Interface
{
    public interface IDayBook
    {
        Task<IEnumerable<DayBook>> GetAllAsync();
        Task <IEnumerable<DayBook>> GetByIdAsync(int Id);
        Task <IEnumerable<DayBook>> AddAsync(IEnumerable<DayBook> dayBook);
        Task <DayBook> UpdateAsync(DayBook dayBook);
        Task <DayBook> DeleteAsync(int Id);
    }
}
