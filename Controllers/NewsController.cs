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
        [Route("post")]
        public async Task<News> CreateNews(IFormCollection obj)
        {
            var news = new News()
            {
                NewsId = 0,
                NewsText = obj["NewsText"],
                Image = obj.Files["Image"],
                NewsTitle = obj["NewsTitle"],
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Convert.ToInt32(obj["CreatedBy"]),
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy= Convert.ToInt32(obj["CreatedBy"]),
                IsActive=true,
                IsDeleted=false,
            };

            return await _newsRepository.AddAsync(news);
        }
        [HttpPost]
        [Route("update")]
        public async Task<News> NewsUpdate(IFormCollection obj)
        {
            var news = new News()
            {
                NewsId = Convert.ToInt32(obj["NewsId"]),
                NewsText = obj["NewsText"],
                Image = obj.Files["Image"],
                NewsTitle = obj["NewsTitle"],
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Convert.ToInt32(obj["CreatedBy"]),
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = Convert.ToInt32(obj["CreatedBy"]),
                IsActive = true,
                IsDeleted = false,
            };
            return await _newsRepository.UpdateAsync(news);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<News> NewsDelete(int id)
        {
            return await _newsRepository.DeleteAsync(id);
        }
    }
}
