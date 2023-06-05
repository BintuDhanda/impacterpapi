using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class CourseCategoryRepository : ICourseCategory
    {
        private readonly AppDbContext _appDbcontext;
        public CourseCategoryRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<CourseCategory>> GetAllAsync()
        {
            return await _appDbcontext.CourseCategory.ToListAsync();
        }
        public async Task<CourseCategory> GetByIdAsync(int Id)
        {
            return await _appDbcontext.CourseCategory.FindAsync(Id);
        }
        public async Task<CourseCategory> AddAsync(CourseCategory courseCategory)
        {
            _appDbcontext.CourseCategory.Add(courseCategory);
            await _appDbcontext.SaveChangesAsync();
            return courseCategory;
        }
        public async Task<CourseCategory> UpdateAsync(CourseCategory courseCategory)
        {
            _appDbcontext.CourseCategory.Update(courseCategory);
            await _appDbcontext.SaveChangesAsync();
            return courseCategory;
        }
        public async Task<CourseCategory> DeleteAsync(int Id)
        {
            var courseCategory = await _appDbcontext.CourseCategory.FindAsync(Id);
            _appDbcontext.CourseCategory.Remove(courseCategory);
            await _appDbcontext.SaveChangesAsync();
            return courseCategory;
        }
    }
}
