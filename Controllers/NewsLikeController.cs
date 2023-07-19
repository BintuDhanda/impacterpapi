using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLikeController : ControllerBase
    {
        private readonly INewsLike _newsLikeRepository;
        public NewsLikeController(INewsLike newsLikeRepository)
        {
            _newsLikeRepository = newsLikeRepository;
        }
        [HttpGet]
        [Route("getNewsLikeByNewsId")]
        public async Task<IEnumerable<NewsLike>> GetNewsLikeByNewsId(int NewsId)
        {
            return await _newsLikeRepository.GetNewsLikeByNewsIdAsync(NewsId);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<NewsLike> GetById(int Id)
        {
            return await _newsLikeRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> NewsLikeAdd([FromBody] NewsLike newsLike)
        {
            return await _newsLikeRepository.AddAsync(newsLike);
        }
        [HttpPost]
        [Route("put")]
        public async Task<NewsLike> NewsLikeUpdate(NewsLike newsLike)
        {
            return await _newsLikeRepository.UpdateAsync(newsLike);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<NewsLike> NewsLikeDelete(int Id)
        {
            return await (_newsLikeRepository.DeleteAsync(Id));
        }
    }
}
