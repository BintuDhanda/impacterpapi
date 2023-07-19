using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICity _cityRepository;
        public CityController(ICity city)
        {
            _cityRepository = city;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<City>> Get()
        {
            return await _cityRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<City> GetById(int Id)
        {
            return await _cityRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<City> CityAdd(City city)
        {
            return await _cityRepository.AddAsync(city);
        }
        [HttpPost]
        [Route("put")]
        public async Task<City> CityUpdate(City city)
        {
            return await _cityRepository.UpdateAsync(city);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<City> CityDelete(int Id)
        {
            return await _cityRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getCityByStateId")]
        public async Task<IEnumerable<City>> GetCityByStateId(int Id)
        {
            return await _cityRepository.GetCityByStateIdAsync(Id);
        }
    }
}
