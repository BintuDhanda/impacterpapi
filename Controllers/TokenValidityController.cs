using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenValidityController : ControllerBase
    {
        private readonly ITokenValidity _tokenValidityRepository;
        public TokenValidityController(ITokenValidity tokenValidityRepository)
        {
            _tokenValidityRepository = tokenValidityRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<TokenValidity>> Get()
        {
            return await _tokenValidityRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<TokenValidity> GetById(int Id)
        {
            return await _tokenValidityRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<TokenValidity> StudentTokenAdd(TokenValidity tokenValidity)
        {
            return await _tokenValidityRepository.AddAsync(tokenValidity);
        }
        [HttpPut]
        [Route("put")]
        public async Task<TokenValidity> StudentTokenUpdate(TokenValidity tokenValidity)
        {
            return await _tokenValidityRepository.UpdateAsync(tokenValidity);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<TokenValidity> StudentTokenDelete(int Id)
        {
            return await _tokenValidityRepository.DeleteAsync(Id);
        }
    }
}
