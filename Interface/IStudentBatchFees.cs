using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface IStudentBatchFees
    {
        Task<IEnumerable<StudentBatchFees>> GetAllAsync();
        Task<StudentBatchFees> GetByIdAsync(int Id);
        Task<StudentBatchFees> AddAsync(StudentBatchFees studentBatchFees);
        Task<StudentBatchFees> UpdateAsync(StudentBatchFees studentBatchFees);
        Task<StudentBatchFees> DeleteAsync(int Id);
        Task<IEnumerable<StudentBatchFees>> GetStudentBatchFeesByRegistrationNumberAsync(StudentBatchFeesSearch studentBatchFeesSearch);
        Task<IActionResult> RegistrationIsExist(StudentBatchFeesSearch studentBatchFeesSearch);
        Task<IActionResult> SumDepositAndRefund(string registrationNumber);
    }
}
