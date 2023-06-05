using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistration _registrationRepository;
        public RegistrationController(IRegistration registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Registration>> Get()
        {
            return await _registrationRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Registration> GetById(int Id)
        {
            return await _registrationRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Registration> RegistrationAdd(Registration registration)
        {
            return await _registrationRepository.AddAsync(registration);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Registration> RegistrationUpdate(Registration registration)
        {
            return await _registrationRepository.UpdateAsync(registration);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Registration> RegistrationDelete(int Id)
        {
            return await _registrationRepository.DeleteAsync(Id);
        }
    }
}
