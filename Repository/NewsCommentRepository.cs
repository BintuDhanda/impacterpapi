using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class NewsCommentRepository : INewsComment
    {
        private readonly AppDbContext _appDbContext;
        public NewsCommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<NewsComment>> GetNewsCommentByNewsIdAsync(int NewsId)
        {
            return await _appDbContext.NewsComment.Where(nc => nc.NewsId == NewsId)
                .Select(nc => new NewsComment
                {
                    NewsCommentId = nc.NewsCommentId,
                    Comment = nc.Comment,
                    NewsId = nc.NewsId,
                    IsActive = nc.IsActive, 
                    IsDeleted = nc.IsDeleted,
                    CreatedAt = nc.CreatedAt,
                    CreatedBy = nc.CreatedBy,
                    LastUpdatedAt = nc.LastUpdatedAt,
                    LastUpdatedBy = nc.LastUpdatedBy,
                    UserName = _appDbContext.StudentDetails.Where(x => x.UserId == nc.CreatedBy).Select(s => s.FirstName.Substring(0, 1) + s.LastName.Substring(0, 1)).FirstOrDefault(),
                    UserMobile = _appDbContext.Users.Where(u => u.Id == nc.CreatedBy).Select(u => u.UserMobile.Substring(0, 3) + "-xxxxx-" + u.UserMobile.Substring(5, 2)).FirstOrDefault(),
                })
                .ToListAsync();
        }
        public async Task<NewsComment> GetByIdAsync(int Id)
        {
            return await _appDbContext.NewsComment.FindAsync(Id);
        }
        public async Task<NewsComment> AddAsync(NewsComment newsComment)
        {
            
                newsComment.CreatedAt = DateTime.UtcNow;
                newsComment.IsDeleted = false;
                _appDbContext.NewsComment.Add(newsComment);
                await _appDbContext.SaveChangesAsync();
                return newsComment;
        }
        public async Task<NewsComment> UpdateAsync(NewsComment newsComment)
        {
            newsComment.LastUpdatedAt = DateTime.UtcNow;
            newsComment.IsDeleted = false;
            _appDbContext.NewsComment.Update(newsComment);
            await _appDbContext.SaveChangesAsync();
            return newsComment;
        }
        public async Task<NewsComment> DeleteAsync(int Id)
        {
            var newsComment = await _appDbContext.NewsComment.FindAsync(Id);
            _appDbContext.Remove(newsComment);
            await _appDbContext.SaveChangesAsync();
            return newsComment;
        }
    }
}
