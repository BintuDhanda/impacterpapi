using ERP.Models;
using ERP.SearchFilters;

namespace ERP.Interface
{
    public interface IStudentTokenFees
    {
        Task<IEnumerable<StudentTokenFees>> GetAllAsync();
        Task<StudentTokenFees> GetByIdAsync(int BatchId);
        Task<StudentTokenFees> AddAsync(StudentTokenFees tokenValidity);
        Task<StudentTokenFees> UpdateAsync(StudentTokenFees tokenValidity);
        Task<StudentTokenFees> DeleteAsync(int Id);
        Task<IEnumerable<StudentTokenFees>> GetStudentTokenFeesByStudentTokenIdAsync(int Id, CommonSearchFilter commonSearchFilter);
    }
}
