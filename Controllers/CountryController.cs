using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountry _countryRepository;
        public CountryController(ICountry countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task <IEnumerable<Country>> Get()
        {
            return await _countryRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Country> GetById(int Id)
        {
            return await _countryRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        [Route("post")]
        public async Task <Country> CountryAdd(Country country)
        {
            return await _countryRepository.AddAsync(country);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("put")]
        public async Task<Country> CountryUpdate (Country country)
        {
            return await _countryRepository.UpdateAsync(country);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("delete")]
        public async Task<Country> CountryDelete(int Id)
        {
            return await _countryRepository.DeleteAsync(Id);
        }
    }
}
