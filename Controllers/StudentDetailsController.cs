using ERP.Bussiness;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
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
        public async Task<StudentDetails> StudentDetailsAdd(IFormCollection obj)
        {
            var studentDetails =  new StudentDetails()
            {
                StudentId = 0,
                Image = obj.Files["StudentImage"],
                FirstName = obj["FirstName"],
                LastName = obj["LastName"],
                FatherName = obj["FatherName"],
                MotherName = obj["MotherName"],
                Gender = obj["Gender"],
                StudentHeight = Convert.ToInt32(obj["StudentHeight"]),
                StudentWeight = Convert.ToInt32(obj["StudentWeight"]),
                BodyRemark = obj["BodyRemark"],
                UserId = Convert.ToInt32(obj["UserId"]),
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Convert.ToInt32(obj["CreatedBy"]),
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = Convert.ToInt32(obj["LastUpdatedBy"]),
            };

            return await _studentDetailsRepository.AddAsync(studentDetails);
        }
        [HttpPost]
        [Route("put")]
        public async Task<StudentDetails> StudentDetailsUpdate(IFormCollection obj)
        {
            var studentDetails = new StudentDetails()
            {
                StudentId = Convert.ToInt32(obj["StudentId"]),
                Image = obj.Files["StudentImage"],
                FirstName = obj["FirstName"],
                LastName = obj["LastName"],
                FatherName = obj["FatherName"],
                MotherName = obj["MotherName"],
                Gender = obj["Gender"],
                StudentHeight = Convert.ToInt32(obj["StudentHeight"]),
                StudentWeight = Convert.ToInt32(obj["StudentWeight"]),
                BodyRemark = obj["BodyRemark"],
                UserId = Convert.ToInt32(obj["UserId"]),
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Convert.ToInt32(obj["CreatedBy"]),
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = Convert.ToInt32(obj["LastUpdatedBy"]),
            };
            return await _studentDetailsRepository.UpdateAsync(studentDetails);
        }
        [HttpGet]
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
        [HttpGet]
        [Route("getStudentIdByRegistrationNumber")]
        public async Task<IActionResult> GetStudentIdByRegistrationNumber(string RegistrationNumber)
        {
            return await _studentDetailsRepository.GetStudentIdByRegistrationNumber(RegistrationNumber);
        }
    }
}
