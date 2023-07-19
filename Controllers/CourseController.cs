using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _courseRepository;
        public CourseController(ICourse courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Course>> Get()
        {
            return await _courseRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Course> GetById(int Id)
        {
            return await _courseRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Course> CourseAdd(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }
        [HttpPost]
        [Route("put")]
        public async Task<Course> CourseUpdate(Course course)
        {
            return await _courseRepository.UpdateAsync(course);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<Course> CourseDelete(int Id)
        {
            return await _courseRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getCourseByCourseCategoryId")]
        public async Task<IEnumerable<Course>> GetCourseByCourseCategoryId(int Id)
        {
            return await _courseRepository.GetCourseByCourseCategoryIdAsync(Id);
        }
    }
}
