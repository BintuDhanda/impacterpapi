using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualification _qualificationRepository;
        public QualificationController(IQualification qualificationRepository)
        {
            _qualificationRepository = qualificationRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Qualification>> Get()
        {
            return await _qualificationRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Qualification> GetById(int Id)
        {
            return await _qualificationRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Qualification> QualificationAdd(Qualification qualification)
        {
            return await _qualificationRepository.AddAsync(qualification);
        }
        [HttpPost]
        [Route("put")]
        public async Task<Qualification> QualificationUpdate(Qualification qualification)
        {
            return await _qualificationRepository.UpdateAsync(qualification);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<Qualification> QualificationDelete(int Id)
        {
            return await _qualificationRepository.DeleteAsync(Id);
        }
    }
}
