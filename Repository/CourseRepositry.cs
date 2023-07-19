using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class CourseRepositry : ICourse
    {
        private readonly AppDbContext _appDbcontext;
        public CourseRepositry(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _appDbcontext.Course.ToListAsync();
        }
        public async Task<Course> GetByIdAsync(int Id)
        {
            return await _appDbcontext.Course.FindAsync(Id);
        }
        public async Task<Course> AddAsync(Course course)
        {
            var courses = await _appDbcontext.Course.Where(c => c.CourseName == course.CourseName).FirstOrDefaultAsync();
            if (courses == null)
            {
            course.CreatedAt = DateTime.UtcNow;
            course.IsDeleted = false;
            _appDbcontext.Course.Add(course);
            await _appDbcontext.SaveChangesAsync();
            return course;
            }
            return courses;
        }
        public async Task<Course> UpdateAsync(Course course)
        {
            var courses = await _appDbcontext.Course.Where(c => c.CourseId == course.CourseId).FirstOrDefaultAsync();
            if (courses != null)
            {
                courses.LastUpdatedAt = DateTime.UtcNow;
                courses.IsDeleted = false;
                courses.CourseName = course.CourseName;
                courses.LastUpdatedBy = course.LastUpdatedBy;
                _appDbcontext.Course.Update(courses);
                await _appDbcontext.SaveChangesAsync();
                return courses;
            }
            return course;
        }
        public async Task<Course> DeleteAsync(int Id)
        {
            var course = await _appDbcontext.Course.FindAsync(Id);
            _appDbcontext.Course.Remove(course);
            await _appDbcontext.SaveChangesAsync();
            return course;
        }
        public async Task<IEnumerable<Course>> GetCourseByCourseCategoryIdAsync(int Id)
        {
            return await _appDbcontext.Course.Where(c=>c.CourseCategoryId == Id).ToListAsync();
        }
    }
}
