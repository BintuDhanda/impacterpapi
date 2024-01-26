using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface IStudentDetails
    {
        Task<IEnumerable<StudentDetails>> GetAllAsync(CommonSearchFilter commonSearchFilter);
        Task<StudentDetails> GetByIdAsync(int Id);
        Task<StudentDetails> AddAsync(StudentDetails studentDetails);
        Task<StudentDetails> UpdateAsync(StudentDetails studentDetails);
        Task<StudentDetails> DeleteAsync(int Id);
        Task<StudentDetails> GetStudentDetailsByUserIdAsync(int userId);
        Task<IActionResult> GetStudentIdByRegistrationNumber(string RegistrationNumber);
    }
}
