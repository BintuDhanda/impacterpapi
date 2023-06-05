using ERP.Models;

namespace ERP.Interface
{
    public interface ICourse
    {
        Task <IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int Id);
        Task<Course> AddAsync(Course course);
        Task<Course> UpdateAsync(Course course);
        Task<Course> DeleteAsync(int Id);
        Task<IEnumerable<Course>> GetCourseByCourseCategoryIdAsync(int Id);
    }
}
