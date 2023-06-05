using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentFees
    {
        Task<IEnumerable<StudentFees>> GetAllAsync();
        Task<StudentFees> GetByIdAsync(int Id);
        Task<StudentFees> AddAsync(StudentFees studentFees);
        Task<StudentFees> UpdateAsync(StudentFees studentFees);
        Task<StudentFees> DeleteAsync(int Id);
    }
}
