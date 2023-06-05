using ERP.Models;

namespace ERP.Interface
{
    public interface ICourseCategory
    {
        Task<IEnumerable<CourseCategory>> GetAllAsync();
        Task<CourseCategory> GetByIdAsync(int Id);
        Task<CourseCategory> AddAsync(CourseCategory courseCategory);
        Task<CourseCategory> UpdateAsync(CourseCategory courseCategory);
        Task<CourseCategory> DeleteAsync(int Id);
    }
}
