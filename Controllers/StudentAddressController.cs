using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAddressController : ControllerBase
    {
        private readonly IStudentAddress _studentAddressRepository;
        public StudentAddressController(IStudentAddress studentAddressRepository)
        {
            _studentAddressRepository = studentAddressRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentAddress>> Get()
        {
            return await _studentAddressRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentAddress> GetById(int Id)
        {
            return await _studentAddressRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<StudentAddress> StudentAddressAdd(StudentAddress studentAddress)
        {
            return await _studentAddressRepository.AddAsync(studentAddress);
        }
        [HttpPost]
        [Route("put")]
        public async Task<StudentAddress> StudentAddressUpdate([FromBody] StudentAddress studentAddress)
        {
            return await _studentAddressRepository.UpdateAsync(studentAddress);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<StudentAddress> StudentAddressDelete(int Id)
        {
            return await _studentAddressRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getStudentAddressByStudentId")]
        public async Task<IEnumerable<StudentAddress>> StudentAddressByStudentId(int Id)
        {
            return await _studentAddressRepository.GetStudentAddressByStudentIdAsync(Id);
        }
    }
}
