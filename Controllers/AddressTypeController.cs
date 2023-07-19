using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        private readonly IAddressType _addressTypeRepository;
        public AddressTypeController(IAddressType addressTypeRepository)
        {
            _addressTypeRepository = addressTypeRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<AddressType>> Get()
        {
            return await _addressTypeRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<AddressType> GetById(int Id)
        {
            return await _addressTypeRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<AddressType> AddressTypeAdd(AddressType addressType)
        {
            return await _addressTypeRepository.AddAsync(addressType);
        }
        [HttpPost]
        [Route("put")]
        public async Task<AddressType> AddressTypeUpdate(AddressType addressType)
        {
            return await _addressTypeRepository.UpdateAsync(addressType);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<AddressType> AddressTypeDelete(int Id)
        {
            return await _addressTypeRepository.DeleteAsync(Id);
        }
    }
}
