using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversity _universityRepository;
        public UniversityController(IUniversity university)
        {
            _universityRepository = university;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<University>> Get()
        {
            return await _universityRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<University> GetById(int Id)
        {
            return await _universityRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("add")]
        public async Task<University> UniversityAdd(University university)
        {
            return await _universityRepository.AddAsync(university);
        }
        [HttpPut]
        [Route("put")]
        public async Task<University> UniversityUpdate(University university)
        {
            return await _universityRepository.UpdateAsync(university);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<University> UniversityDelete(int Id)
        {
            return await _universityRepository.DeleteAsync(Id);
        }
    }
}
