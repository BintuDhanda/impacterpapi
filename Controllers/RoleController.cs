using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _roleRepository;
        public RoleController(IRole roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Roles>> Get()
        {
            return await _roleRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Roles> GetById(int Id)
        {
            return await _roleRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Roles> RoleAdd(Roles role)
        {
            return await _roleRepository.AddAsync(role);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Roles> RoleUpdate(Roles role)
        {
            return await _roleRepository.UpdateAsync(role);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Roles> RoleDelete(int Id)
        {
            return await (_roleRepository.DeleteAsync(Id));
        }
    }
}
