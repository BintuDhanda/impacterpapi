using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentToken
    {
        Task<IEnumerable<StudentToken>> GetAllAsync();
        Task<StudentToken> GetByIdAsync(int Id);
        Task<StudentToken> AddAsync(int UserId, int BatchId);
        Task<StudentToken> UpdateAsync(StudentToken tokenValidity);
        Task<StudentToken> DeleteAsync(int Id);
    }
}
