using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCommentController : ControllerBase
    {
        private readonly INewsComment _newsCommentRepository;
        public NewsCommentController(INewsComment newsCommentRepository)
        {
            _newsCommentRepository = newsCommentRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<NewsComment>> Get()
        {
            return await _newsCommentRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<NewsComment> GetById(int Id)
        {
            return await _newsCommentRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<NewsComment> NewsCommentAdd(NewsComment newsComment)
        {
            return await _newsCommentRepository.AddAsync(newsComment);
        }
        [HttpPut]
        [Route("put")]
        public async Task<NewsComment> NewsCommentUpdate(NewsComment newsComment)
        {
            return await _newsCommentRepository.UpdateAsync(newsComment);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<NewsComment> NewsCommentDelete(int Id)
        {
            return await (_newsCommentRepository.DeleteAsync(Id));
        }
    }
}
