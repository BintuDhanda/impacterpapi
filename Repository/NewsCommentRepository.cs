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
        public async Task<IEnumerable<NewsComment>> GetAllAsync()
        {
            return await _appDbContext.NewsComment.ToListAsync();
        }
        public async Task<NewsComment> GetByIdAsync(int Id)
        {
            return await _appDbContext.NewsComment.FindAsync(Id);
        }
        public async Task<NewsComment> AddAsync(NewsComment newsComment)
        {
            var newsComments = await _appDbContext.NewsComment.Where(x => x.CreatedBy == newsComment.CreatedBy && x.NewsId == newsComment.NewsId).FirstOrDefaultAsync();
            if (newsComments == null)
            {
                newsComment.CreatedAt = DateTime.UtcNow;
                newsComments.IsDeleted = false;
                _appDbContext.NewsComment.Add(newsComment);
                await _appDbContext.SaveChangesAsync();
                return newsComment;
            }
            return newsComments;
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
