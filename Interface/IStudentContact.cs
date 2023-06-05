using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentContact
    {
        Task<IEnumerable<StudentContact>> GetAllAsync();
        Task<StudentContact> GetByIdAsync(int Id);
        Task<StudentContact> AddAsync(StudentContact studentContact);
        Task<StudentContact> UpdateAsync(StudentContact studentContact);
        Task<StudentContact> DeleteAsync(int Id);
    }
}
