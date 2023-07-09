using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class NewsLikeRepository : INewsLike
    {
        private readonly AppDbContext _appDbContext;
        public NewsLikeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<NewsLike>> GetNewsLikeByNewsIdAsync(int NewsId)
        {
            return await _appDbContext.NewsLike.Where(nl=>nl.NewsId == NewsId)
                .Select(nl =>  new NewsLike
                {
                    NewsLikeId = nl.NewsLikeId,
                    NewsId = nl.NewsId,
                    IsActive = nl.IsActive,
                    IsDeleted = nl.IsDeleted,
                    CreatedAt = nl.CreatedAt,
                    CreatedBy = nl.CreatedBy,
                    LastUpdatedAt = nl.LastUpdatedAt,
                    LastUpdatedBy = nl.LastUpdatedBy,
                    UserName = _appDbContext.StudentDetails.Where(x => x.UserId == nl.CreatedBy).Select(s => s.FirstName.Substring(0,1) + s.LastName.Substring(0,1)).FirstOrDefault(),
                    UserMobile = _appDbContext.Users.Where(u => u.Id == nl.CreatedBy).Select(u => u.UserMobile.Substring(0, 3) + "-xxxxx-" + u.UserMobile.Substring(5, 2)).FirstOrDefault(),
                })
                .ToListAsync();
        }
        public async Task<NewsLike> GetByIdAsync(int Id)
        {
            return await _appDbContext.NewsLike.FindAsync(Id);
        }
        public async Task<IActionResult> AddAsync(NewsLike newsLike)
        {
            var newsLikes = await _appDbContext.NewsLike.Where(x => x.CreatedBy == newsLike.CreatedBy && x.NewsId == newsLike.NewsId).FirstOrDefaultAsync();
            if (newsLikes != null)
            {
                 _appDbContext.NewsLike.Remove(newsLikes);
                await _appDbContext.SaveChangesAsync();
                return new JsonResult(new
                {
                    Success = true,
                    TotalLikes = _appDbContext.NewsLike.Where(n => n.NewsId == newsLike.NewsId).Count()
                });
            }
            else
            {
                newsLike.CreatedAt = DateTime.UtcNow;
                newsLike.IsDeleted = false;
                _appDbContext.NewsLike.Add(newsLike);
                await _appDbContext.SaveChangesAsync();
                return new JsonResult(new
                {
                    Success = true,
                    TotalLikes =  _appDbContext.NewsLike.Where(n => n.NewsId == newsLike.NewsId).Count()
                });
            }
        }
        public async Task<NewsLike> UpdateAsync(NewsLike newsLike)
        {
            newsLike.LastUpdatedAt = DateTime.UtcNow;
            newsLike.IsDeleted = false;
            _appDbContext.NewsLike.Update(newsLike);
            await _appDbContext.SaveChangesAsync();
            return newsLike;
        }
        public async Task<NewsLike> DeleteAsync(int Id)
        {
            var newsLike = await _appDbContext.NewsLike.FindAsync(Id);
            _appDbContext.NewsLike.Remove(newsLike);
            await _appDbContext.SaveChangesAsync();
            return newsLike;
        }
    }
}
