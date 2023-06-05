using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeTypeController : ControllerBase
    {
        private readonly IFeeType feeTypeRepository;
        public FeeTypeController(IFeeType feeType)
        {
            feeTypeRepository = feeType;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<FeeType>> Get()
        {
            return await feeTypeRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<FeeType> GetById(int Id)
        {
            return await feeTypeRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<FeeType> FeeTypeAdd(FeeType feeType)
        {
            return await feeTypeRepository.AddAsync(feeType);
        }
        [HttpPut]
        [Route("put")]
        public async Task<FeeType> FeeTypeUpdate(FeeType feeType)
        {
            return await feeTypeRepository.UpdateAsync(feeType);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<FeeType> FeeTypeDelete(int Id)
        {
            return await feeTypeRepository.DeleteAsync(Id);
        }
    }
}
