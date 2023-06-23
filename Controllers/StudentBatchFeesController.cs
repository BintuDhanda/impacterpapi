using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBatchFeesController : ControllerBase
    {
        private readonly IStudentBatchFees _studentBatchFeesRepository;
        public StudentBatchFeesController(IStudentBatchFees studentFeesRepository)
        {
            _studentBatchFeesRepository = studentFeesRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentBatchFees>> Get()
        {
            return await _studentBatchFeesRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentBatchFees> GetById(int Id)
        {
            return await _studentBatchFeesRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentBatchFees> StudentBatchFeesAdd(StudentBatchFees studentBatchFees)
        {
            return await _studentBatchFeesRepository.AddAsync(studentBatchFees);
        }
        [HttpPut]
        [Route("put")]
        public async Task<StudentBatchFees> StudentBatchFeesUpdate(StudentBatchFees studentBatchFees)
        {
            return await _studentBatchFeesRepository.UpdateAsync(studentBatchFees);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<StudentBatchFees> StudentBatchFeesDelete(int Id)
        {
            return await _studentBatchFeesRepository.DeleteAsync(Id);
        }
        [HttpPost]
        [Route("getStudentBatchFeesByStudentBatchId")]
        public async Task<IEnumerable<StudentBatchFees>> GetStudentBatchFeesByStudentBatchId ( int Id, CommonSearchFilter commonSearchFilter)
        {
            return await _studentBatchFeesRepository.GetStudentBatchFeesByStudentBatchIdAsync(Id, commonSearchFilter);
        }
    }
}
