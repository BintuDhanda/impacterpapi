using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentAddress
    {
        Task<IEnumerable<StudentAddress>> GetAllAsync();
        Task<StudentAddress> GetByIdAsync(int Id);
        Task<StudentAddress> AddAsync(StudentAddress studentAddress);
        Task<StudentAddress> UpdateAsync(StudentAddress studentAddress);
        Task<StudentAddress> DeleteAsync(int Id);
        Task<IEnumerable<StudentAddress>> GetAllJoinAsync(int Id);
    }
}
