using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentHostelRoomBadRent
    {
        Task<IEnumerable<StudentHostelRoomBadRent>> GetAllAsync(int studentId);
        Task<StudentHostelRoomBadRent> GetByIdAsync(int Id);
    }
}
