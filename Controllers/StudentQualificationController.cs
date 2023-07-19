using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentQualificationController : ControllerBase
    {
        private readonly IStudentQualification _studentQualificationRepository;
        public StudentQualificationController(IStudentQualification qualificationRepository)
        {
            _studentQualificationRepository = qualificationRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentQualification>> Get()
        {
            return await _studentQualificationRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentQualification> GetById(int Id)
        {
            return await _studentQualificationRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentQualification> StudentQualificationAdd(StudentQualification studentQualification)
        {
            return await _studentQualificationRepository.AddAsync(studentQualification);
        }
        [HttpPost]
        [Route("put")]
        public async Task<StudentQualification> StudentQualificationUpdate(StudentQualification studentQualification)
        {
            return await _studentQualificationRepository.UpdateAsync(studentQualification);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<StudentQualification> StudentQualificationDelete(int Id)
        {
            return await _studentQualificationRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getStudentQualificationByStudentId")]
        public async Task<IEnumerable<StudentQualification>> GetStudentQualificationByStudentId(int Id)
        {
            return await _studentQualificationRepository.GetStudentQualificationByStudentIdAsync(Id);
        }
    }
}
