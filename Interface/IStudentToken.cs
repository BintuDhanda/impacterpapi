using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentToken
    {
        Task<IEnumerable<StudentToken>> GetAllAsync();
        Task<StudentToken> GetByIdAsync(int Id);
        //Task<StudentToken> AddAsync(int StudentId, int BatchId);
        Task<StudentToken> AddAsync(StudentToken studentToken);
        Task<StudentToken> UpdateAsync(StudentToken tokenValidity);
        Task<StudentToken> DeleteAsync(int Id);
        Task<IEnumerable<StudentToken>> GetStudentTokenByStudentIdAsync(int StudentId);
    }
}
