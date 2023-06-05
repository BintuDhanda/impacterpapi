using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentFeesController : ControllerBase
    {
        private readonly IStudentFees _studentFeesRepository;
        public StudentFeesController(IStudentFees studentFeesRepository)
        {
            _studentFeesRepository = studentFeesRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentFees>> Get()
        {
            return await _studentFeesRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentFees> GetById(int Id)
        {
            return await _studentFeesRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentFees> StudentFeesAdd(StudentFees studentFees)
        {
            return await _studentFeesRepository.AddAsync(studentFees);
        }
        [HttpPut]
        [Route("put")]
        public async Task<StudentFees> StudentFeesUpdate(StudentFees studentFees)
        {
            return await _studentFeesRepository.UpdateAsync(studentFees);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<StudentFees> StudentFeesDelete(int Id)
        {
            return await _studentFeesRepository.DeleteAsync(Id);
        }
    }
}
