using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : ControllerBase
    {
        private readonly IPincode _pincodeRepositry;
        public PincodeController(IPincode pincodeRepositry)
        {
            _pincodeRepositry = pincodeRepositry;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Pincode>> Get()
        {
            return await _pincodeRepositry.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Pincode> GetBYId(int Id)
        {
            return await _pincodeRepositry.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Pincode> PincodeAdd(Pincode pincode)
        {
            return await _pincodeRepositry.AddAsync(pincode);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Pincode> PincodeUpdate(Pincode pincode)
        {
            return await _pincodeRepositry.UpdateAsync(pincode);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Pincode> PincodeDelete(int Id)
        {
            return await _pincodeRepositry.DeleteAsync(Id);
        }
    }
}
