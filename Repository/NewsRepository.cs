using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ERP.Bussiness
{
    public class NewsRepository : INews
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsRepository(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IEnumerable<News>> GetAllAsync(NewsSearchFilter newsSearchFilter)
        {
            var news = await _appDbContext.News
                        .Where(n => !string.IsNullOrEmpty(newsSearchFilter.NewsTitle) ? n.NewsTitle == newsSearchFilter.NewsTitle : n.CreatedAt >= Convert.ToDateTime(newsSearchFilter.From).ToUniversalTime() &&
                         n.CreatedAt <= Convert.ToDateTime(newsSearchFilter.To).ToUniversalTime())
                        .Select(n => new News
                        {
                            NewsId = n.NewsId,
                            NewsImage = n.NewsImage,
                            NewsText = n.NewsText,
                            NewsTitle = n.NewsTitle,
                            IsActive = n.IsActive,
                            CreatedAt = n.CreatedAt,
                            TotalLikes = _appDbContext.NewsLike.Where(w=>w.NewsId==n.NewsId).Count(),
                            TotalComments = _appDbContext.NewsComment.Where(w => w.NewsId == n.NewsId).Count(),
                            IsLiked= (_appDbContext.NewsLike.Where(w => w.NewsId == n.NewsId && w.CreatedBy== newsSearchFilter.CreatedBy).FirstOrDefault()==null)?false:true,
                            IsCommented= (_appDbContext.NewsComment.Where(w => w.NewsId == n.NewsId && w.CreatedBy == newsSearchFilter.CreatedBy).FirstOrDefault() == null )? false : true,
                            TotalNews = _appDbContext.News.Where(u => u.IsActive == true).Count(),
                        })
                        .OrderByDescending(o => o.NewsId)
                        .Skip(newsSearchFilter.Skip)
                        .Take(newsSearchFilter.Take)
                        .ToListAsync();
            return news;
        }
        public async Task<IEnumerable<News>> GetAllNewsAsync(NewsSearchFilter newsSearchFilter)
        {
            var news = await _appDbContext.News
                        .Select(n => new News
                        {
                            NewsId = n.NewsId,
                            NewsImage = n.NewsImage,
                            NewsText = n.NewsText,
                            NewsTitle = n.NewsTitle,
                            IsActive = n.IsActive,
                            CreatedAt = n.CreatedAt,
                            TotalLikes = _appDbContext.NewsLike.Where(w=>w.NewsId==n.NewsId).Count(),
                            TotalComments = _appDbContext.NewsComment.Where(w => w.NewsId == n.NewsId).Count(),
                            IsLiked= (_appDbContext.NewsLike.Where(w => w.NewsId == n.NewsId && w.CreatedBy== newsSearchFilter.CreatedBy).FirstOrDefault()==null)?false:true,
                            IsCommented= (_appDbContext.NewsComment.Where(w => w.NewsId == n.NewsId && w.CreatedBy == newsSearchFilter.CreatedBy).FirstOrDefault() == null )? false : true,
                            TotalNews = _appDbContext.News.Where(u => u.IsActive == true).Count(),
                        })
                        .OrderByDescending(o => o.NewsId)
                        .Skip(newsSearchFilter.Skip)
                        .Take(newsSearchFilter.Take)
                        .ToListAsync();
            return news;
        }
        public async Task<News> GetByIdAsync(int id)
        {
            return await _appDbContext.News.FindAsync(id);
        }
        public async Task<News> AddAsync(News news)
        {
            string filePath = "";
            if (news.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + news.Image.FileName;
                filePath  = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await news.Image.CopyToAsync(fileStream);
                }

                filePath = "/uploads/" + uniqueFileName;
            }
            news.NewsImage = filePath;
            news.CreatedAt = DateTime.UtcNow;
            news.IsDeleted = false;
            _appDbContext.News.Add(news);
            await _appDbContext.SaveChangesAsync();
            return news;
        }
        public async Task<News> UpdateAsync(News news)
        {
            var record = await _appDbContext.News.Where(w => w.NewsId == news.NewsId).FirstOrDefaultAsync();
            string filePath = "";

            if(record != null)
            {
                if (news.Image != null)
                {
                    var path = "wwwroot" + record.NewsImage;
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + news.Image.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await news.Image.CopyToAsync(fileStream);
                    }
                    filePath = "/uploads/" + uniqueFileName;
                }
                record.NewsImage = filePath;
                record.NewsText=news.NewsText;
                record.NewsTitle = news.NewsTitle;
                record.LastUpdatedAt = DateTime.UtcNow;
                record.IsActive = news.IsActive;
                _appDbContext.News.Update(record);
                await _appDbContext.SaveChangesAsync();
            }
            return news; 
        }

        public async Task<News> DeleteAsync(int Id)
        {

            var record = await _appDbContext.News.Where(w => w.NewsId == Id).FirstOrDefaultAsync();
            if (record != null)
            {
                var path = "wwwroot"+ record.NewsImage;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                _appDbContext.News.Remove(record);
                await _appDbContext.SaveChangesAsync();
            }

            return record;

        }
    }
}
