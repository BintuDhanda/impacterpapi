using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentIdentitiesController : ControllerBase
    {
        private readonly IStudentIdentities _studentIdentitiesRepository;
        public StudentIdentitiesController(IStudentIdentities studentIdentitiesRepository)
        {
            _studentIdentitiesRepository = studentIdentitiesRepository;
        }
        [HttpGet]
        [Route("getStudentIdentitiesByStudentBatchId")]
        public async Task<IEnumerable<StudentIdentities>> GetStudentIdentitiesByStudentBatchId(int Id)
        {
            return await _studentIdentitiesRepository.GetStudentIdentitiesByStudentBatchId(Id);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentIdentities> GetById(int Id)
        {
            return await _studentIdentitiesRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentIdentities> StudentIdentitiesAdd(StudentIdentities studentIdentities)
        {
            return await _studentIdentitiesRepository.AddAsync(studentIdentities);
        }
        [HttpPost]
        [Route("put")]
        public async Task<StudentIdentities> StudentIdentitiesUpdate(StudentIdentities studentIdentities)
        {
            return await _studentIdentitiesRepository.UpdateAsync(studentIdentities);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<StudentIdentities> StudentIdentitiesDelete(int Id)
        {
            return await _studentIdentitiesRepository.DeleteAsync(Id);
        }
    }
}
