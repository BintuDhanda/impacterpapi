using ERP.Models;
using ERP.SearchFilters;

namespace ERP.Interface
{
    public interface IStudentBatchFees
    {
        Task<IEnumerable<StudentBatchFees>> GetAllAsync();
        Task<StudentBatchFees> GetByIdAsync(int Id);
        Task<StudentBatchFees> AddAsync(StudentBatchFees studentBatchFees);
        Task<StudentBatchFees> UpdateAsync(StudentBatchFees studentBatchFees);
        Task<StudentBatchFees> DeleteAsync(int Id);
        Task<IEnumerable<StudentBatchFees>> GetStudentBatchFeesByStudentBatchIdAsync(int Id, CommonSearchFilter commonSearchFilter);
    }
}
