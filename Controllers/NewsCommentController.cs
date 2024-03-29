﻿using ERP.Interface;
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
        [Route("getNewsCommentByNewsId")]
        public async Task<IEnumerable<NewsComment>> Get(int NewsId)
        {
            return await _newsCommentRepository.GetNewsCommentByNewsIdAsync(NewsId);
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
        [HttpPost]
        [Route("put")]
        public async Task<NewsComment> NewsCommentUpdate(NewsComment newsComment)
        {
            return await _newsCommentRepository.UpdateAsync(newsComment);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<NewsComment> NewsCommentDelete(int Id)
        {
            return await (_newsCommentRepository.DeleteAsync(Id));
        }
    }
}
