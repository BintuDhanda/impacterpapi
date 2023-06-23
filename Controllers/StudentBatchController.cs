using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBatchController : ControllerBase
    {
        private readonly IStudentBatch _studentBatchRepository;
        public StudentBatchController(IStudentBatch studentBatchRepository)
        {
            _studentBatchRepository = studentBatchRepository;
        }
        [HttpGet]
        [Route("getStudentBatchByStudentId")]
        public async Task<IEnumerable<StudentBatch>> GetStudentBatchByStudentId(int Id)
        {
            return await _studentBatchRepository.GetStudentBatchByStudentId(Id);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentBatch> GetById(int Id)
        {
            return await _studentBatchRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentBatch> StudentBatchAdd(StudentBatch studentBatch)
        {
            return await _studentBatchRepository.AddAsync(studentBatch);
        }
        [HttpPut]
        [Route("put")]
        public async Task<StudentBatch> StudentBatchUpdate(StudentBatch studentBatch)
        {
            return await _studentBatchRepository.UpdateAsync(studentBatch);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<StudentBatch> StudentBatchDelete(int Id)
        {
            return await _studentBatchRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getStudents")]
        public async Task<IEnumerable<Users>> GetStudents()
        {
            return await _studentBatchRepository.GetStudentsAsync();
        }
    }
}
