using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategory _courseCategoryRepository;
        public CourseCategoryController(ICourseCategory courseCategoryRepository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<CourseCategory>> Get()
        {
            return await _courseCategoryRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<CourseCategory> GetById(int Id)
        {
            return await _courseCategoryRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<CourseCategory> CourseCategoryAdd(CourseCategory courseCategory)
        {
            return await _courseCategoryRepository.AddAsync(courseCategory);
        }
        [HttpPut]
        [Route("put")]
        public async Task<CourseCategory> CourseCategoryUpdate(CourseCategory courseCategory)
        {
            return await _courseCategoryRepository.UpdateAsync(courseCategory);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<CourseCategory> CourseCategoryDelete(int Id)
        {
            return await _courseCategoryRepository.DeleteAsync(Id);
        }
    }
}
