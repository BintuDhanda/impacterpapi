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
        [Route("roleGet")]
        public async Task<IEnumerable<Roles>> Get()
        {
            return await _roleRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("roleGetById")]
        public async Task<Roles> GetById(int Id)
        {
            return await _roleRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("rolePost")]
        public async Task<Roles> RoleAdd(Roles role)
        {
            return await _roleRepository.AddAsync(role);
        }
        [HttpPost]
        [Route("roleUpdate")]
        public async Task<Roles> RoleUpdate(Roles role)
        {
            return await _roleRepository.UpdateAsync(role);
        }
        [HttpGet]
        [Route("roleDelete")]
        public async Task<Roles> RoleDelete(int Id)
        {
            return await (_roleRepository.DeleteAsync(Id));
        }
    }
}
