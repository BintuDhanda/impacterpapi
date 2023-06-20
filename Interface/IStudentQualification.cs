using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentQualification
    {
        Task<IEnumerable<StudentQualification>> GetAllAsync();
        Task<StudentQualification> GetByIdAsync(int Id);
        Task<StudentQualification> AddAsync(StudentQualification studentQualification);
        Task<StudentQualification> UpdateAsync(StudentQualification studentQualification);
        Task<StudentQualification> DeleteAsync(int Id);
        Task<IEnumerable<StudentQualification>> GetStudentQualificationByStudentIdAsync(int Id);
    }
}
