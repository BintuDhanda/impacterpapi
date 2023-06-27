using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface IStudentTokenFees
    {
        Task<IEnumerable<StudentTokenFees>> GetAllAsync();
        Task<StudentTokenFees> GetByIdAsync(int BatchId);
        Task<StudentTokenFees> AddAsync(StudentTokenFees tokenValidity);
        Task<StudentTokenFees> UpdateAsync(StudentTokenFees tokenValidity);
        Task<StudentTokenFees> DeleteAsync(int Id);
        Task<IEnumerable<StudentTokenFees>> GetStudentTokenFeesByTokenNumberAsync(StudentTokenFeesSearch studentTokenFeesSearch);
        Task<IActionResult> TokenIsExist(StudentTokenFeesSearch studentTokenFeesSearch);
        Task<IActionResult> SumDepositAndRefund();
    }
}
