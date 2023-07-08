using ERP.Bussiness;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INews _newsRepository;
        public NewsController(INews newsRepository)
        {
            _newsRepository = newsRepository;
        }
        [HttpPost]
        [Route("get")]
        public async Task<IEnumerable<News>> Get(NewsSearchFilter newsSearchFilter)
        {
            return await _newsRepository.GetAllAsync(newsSearchFilter);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<News> GetById(int Id)
        {
            return await _newsRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        public async Task<News> CreateNews([FromForm] News news)
        {
            return await _newsRepository.AddAsync(news);
        }
        [HttpPut]
        [Route("put")]
        public async Task<News> NewsUpdate([FromForm] News news)
        {
            return await _newsRepository.UpdateAsync(news);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<News> NewsDelete(int id)
        {
            return await _newsRepository.DeleteAsync(id);
        }
    }
}
