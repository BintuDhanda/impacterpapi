using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillageController : ControllerBase
    {
        private readonly IVillage _villageRepository;
        public VillageController(IVillage village)
        {
            _villageRepository = village;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Village>> Get()
        {
            return await _villageRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Village> GetById(int Id)
        {
            return await _villageRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Village> VillageAdd(Village village)
        {
            return await _villageRepository.AddAsync(village);
        }
        [HttpPost]
        [Route("put")]
        public async Task<Village> VillageUpdate(Village village)
        {
            return await _villageRepository.UpdateAsync(village);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<Village> VillageDelete(int Id)
        {
            return await _villageRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getVillageByCityId")]
        public async Task<IEnumerable<Village>> GetVillageByCityId(int Id)
        {
            return await _villageRepository.GetVillageByCityIdAsync(Id);
        }
    }
}
