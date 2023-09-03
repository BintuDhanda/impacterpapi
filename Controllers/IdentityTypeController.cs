using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityTypeController : ControllerBase
    {
        private readonly IIdentityType _identityTypeRepository;
        public IdentityTypeController(IIdentityType identityTypeRepository)
        {
            _identityTypeRepository = identityTypeRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<IdentityType>> Get()
        {
            return await _identityTypeRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<IdentityType> GetById(int Id)
        {
            return await _identityTypeRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<IdentityType> IdentityTypeAdd(IdentityType identityType)
        {
            return await _identityTypeRepository.AddAsync(identityType);
        }
        [HttpPost]
        [Route("put")]
        public async Task<IdentityType> IdentityTypeUpdate(IdentityType identityType)
        {
            return await _identityTypeRepository.UpdateAsync(identityType);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<IdentityType> IdentityTypeDelete(int Id)
        {
            return await _identityTypeRepository.DeleteAsync(Id);
        }
    }
}
