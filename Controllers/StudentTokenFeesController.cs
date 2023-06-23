using ERP.Bussiness;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTokenFeesController : ControllerBase
    {
        private readonly IStudentTokenFees _studentTokenFeesRepository;
        public StudentTokenFeesController(IStudentTokenFees tokenValidityRepository)
        {
            _studentTokenFeesRepository = tokenValidityRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentTokenFees>> Get()
        {
            return await _studentTokenFeesRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentTokenFees> GetById(int Id)
        {
            return await _studentTokenFeesRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentTokenFees> StudentTokenFeesAdd(StudentTokenFees studentTokenFees)
        {
            return await _studentTokenFeesRepository.AddAsync(studentTokenFees);
        }
        [HttpPut]
        [Route("put")]
        public async Task<StudentTokenFees> StudentTokenFeesUpdate(StudentTokenFees studentTokenFees)
        {
            return await _studentTokenFeesRepository.UpdateAsync(studentTokenFees);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<StudentTokenFees> StudentTokenFeesDelete(int Id)
        {
            return await _studentTokenFeesRepository.DeleteAsync(Id);
        }
        [HttpPost]
        [Route("getStudentTokenFeesByStudentTokenId")]
        public async Task<IEnumerable<StudentTokenFees>> GetStudentTokenFeesByStudentTokenId(int Id, CommonSearchFilter commonSearchFilter)
        {
            return await _studentTokenFeesRepository.GetStudentTokenFeesByStudentTokenIdAsync(Id, commonSearchFilter);
        }
    }
}
