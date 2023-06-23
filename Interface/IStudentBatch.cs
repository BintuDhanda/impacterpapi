using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentBatch
    {
        Task<IEnumerable<StudentBatch>> GetStudentBatchByStudentId(int Id);
        Task<StudentBatch> GetByIdAsync(int Id);
        Task<StudentBatch> AddAsync(StudentBatch studentBatch);
        Task<StudentBatch> UpdateAsync(StudentBatch studentBatch);
        Task<StudentBatch> DeleteAsync(int Id);
        Task<IEnumerable<Users>> GetStudentsAsync();
    }
}
