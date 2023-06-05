using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentContactController : ControllerBase
    {
        private readonly IStudentContact _studentContactRepository;
        public StudentContactController(IStudentContact studentContactRepository)
        {
            _studentContactRepository = studentContactRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentContact>> Get()
        {
            return await _studentContactRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentContact> GetById(int Id)
        {
            return await _studentContactRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentContact> StudentContactAdd(StudentContact studentContact)
        {
            return await _studentContactRepository.AddAsync(studentContact);
        }
        [HttpPut]
        [Route("put")]
        public async Task<StudentContact> StudentContactUpdate(StudentContact studentContact)
        {
            return await _studentContactRepository.UpdateAsync(studentContact);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<StudentContact> StudentContactDelete(int Id)
        {
            return await _studentContactRepository.DeleteAsync(Id);
        }
    }
}
