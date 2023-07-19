using ERP.Bussiness;
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
        [HttpPost]
        [Route("put")]
        public async Task<StudentBatchFees> StudentBatchFeesUpdate(StudentBatchFees studentBatchFees)
        {
            return await _studentBatchFeesRepository.UpdateAsync(studentBatchFees);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<StudentBatchFees> StudentBatchFeesDelete(int Id)
        {
            return await _studentBatchFeesRepository.DeleteAsync(Id);
        }
        [HttpPost]
        [Route("getStudentBatchFeesByRegistrationNumber")]
        public async Task<IEnumerable<StudentBatchFees>> GetStudentBatchFeesByRegistrationNumber ( StudentBatchFeesSearch studentBatchFeesSearch)
        {
            return await _studentBatchFeesRepository.GetStudentBatchFeesByRegistrationNumberAsync(studentBatchFeesSearch);
        }
        [HttpPost]
        [Route("RegistrationIsExists")]
        public async Task<IActionResult> RegistrationIsExists([FromBody] StudentBatchFeesSearch studentBatchFeesSearch)
        {
            return await _studentBatchFeesRepository.RegistrationIsExist(studentBatchFeesSearch);
        }
        [HttpGet]
        [Route("sumDepositAndRefund")]
        public async Task<IActionResult> SumDepositAndRefund(string registrationNumber)
        {
            return await _studentBatchFeesRepository.SumDepositAndRefund(registrationNumber);
        }
    }
}
