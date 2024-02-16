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
            var courseCategorys = await _appDbcontext.CourseCategory.Where(cC => cC.CourseCategoryName == courseCategory.CourseCategoryName).FirstOrDefaultAsync();
            if (courseCategorys == null)
            {
                courseCategory.CreatedAt = DateTime.UtcNow;
                courseCategory.IsDeleted = false;
                _appDbcontext.CourseCategory.Add(courseCategory);
                await _appDbcontext.SaveChangesAsync();
                return courseCategory;
            }
            return courseCategorys;
        }
        public async Task<CourseCategory> UpdateAsync(CourseCategory courseCategory)
        {
            var isExist = await _appDbcontext.CourseCategory.Where(cC => cC.CourseCategoryName == courseCategory.CourseCategoryName && cC.CourseCategoryId != courseCategory.CourseCategoryId).AnyAsync();
            if (!isExist)
            {
                var courseCategorys = await _appDbcontext.CourseCategory.Where(cC => cC.CourseCategoryId == courseCategory.CourseCategoryId).FirstOrDefaultAsync();
                if (courseCategorys != null)
                {
                    courseCategorys.LastUpdatedAt = DateTime.UtcNow;
                    courseCategorys.IsDeleted = false;
                    courseCategorys.CourseCategoryName = courseCategory.CourseCategoryName;
                    courseCategorys.LastUpdatedBy = courseCategory.LastUpdatedBy;
                    _appDbcontext.CourseCategory.Update(courseCategorys);
                    await _appDbcontext.SaveChangesAsync();
                    return courseCategorys;
                }
            }
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
