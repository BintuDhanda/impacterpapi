using ERP.Bussiness;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private readonly IStudentDetails _studentDetailsRepository;
        public StudentDetailsController(IStudentDetails studentDetailsRepository)
        {
            _studentDetailsRepository = studentDetailsRepository;
        }
        [HttpPost]
        [Route("get")]
        public async Task<IEnumerable<StudentDetails>> Get(CommonSearchFilter commonSearchFilter)
        {
            return await _studentDetailsRepository.GetAllAsync(commonSearchFilter);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentDetails> GetById(int Id)
        {
            return await _studentDetailsRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentDetails> StudentDetailsAdd(StudentDetails studentDetails)
        {
            return await _studentDetailsRepository.AddAsync(studentDetails);
        }
        [HttpPut]
        [Route("put")]
        public async Task<StudentDetails> StudentDetailsUpdate(StudentDetails studentDetails)
        {
            return await _studentDetailsRepository.UpdateAsync(studentDetails);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<StudentDetails> StudentDetailsDelete(int Id)
        {
            return await _studentDetailsRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getStudentDetailsByUserId")]
        public async Task<StudentDetails> GetStudentDetailsByUserId(int UserId)
        {
            return await _studentDetailsRepository.GetStudentDetailsByUserIdAsync(UserId);
        }
    }
}
