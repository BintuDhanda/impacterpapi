using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentRepository;
        public StudentController (IStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _studentRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Student> GetById(int Id)
        {
            return await _studentRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Student> StudentAdd(Student student)
        {
            return await _studentRepository.AddAsync(student);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Student> StudentUpdate(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Student> StudentDelete(int Id)
        {
            return await _studentRepository.DeleteAsync(Id);
        }
    }
}
