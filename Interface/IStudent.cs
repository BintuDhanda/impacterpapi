using ERP.Models;

namespace ERP.Interface
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int Id);
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<Student> DeleteAsync(int Id);
    }
}
