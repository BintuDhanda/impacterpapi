using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentIdentities
    {
        Task<IEnumerable<StudentIdentities>> GetStudentIdentitiesByStudentBatchId(int Id);
        Task<StudentIdentities> GetByIdAsync(int Id);
        Task<StudentIdentities> AddAsync(StudentIdentities studentIdentities);
        Task<StudentIdentities> UpdateAsync(StudentIdentities studentIdentities);
        Task<StudentIdentities> DeleteAsync(int Id);
    }
}
