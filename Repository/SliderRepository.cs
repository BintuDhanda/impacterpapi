using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class SliderRepository : ISlider
    {
        private readonly AppDbContext _appDbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SliderRepository(AppDbContext appDbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbcontext = appDbcontext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _appDbcontext.Slider.ToListAsync();
        }
        public async Task<Slider> GetByIdAsync(int Id)
        {
            return await _appDbcontext.Slider.FindAsync(Id);
        }
        public async Task<Slider> AddAsync(Slider slider)
        {
                string filePath = "";
                if (slider.Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "slider");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + slider.Image.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await slider.Image.CopyToAsync(fileStream);
                    }

                    filePath = "/slider/" + uniqueFileName;
                }
                slider.SliderImage = filePath;
                slider.CreatedAt = DateTime.UtcNow;
                slider.IsDeleted = false;
                _appDbcontext.Slider.Add(slider);
                await _appDbcontext.SaveChangesAsync();
                return slider;
        }
        public async Task<Slider> UpdateAsync(Slider slider)
        {
            var record = await _appDbcontext.Slider.Where(sd => sd.SliderId == slider.SliderId).FirstOrDefaultAsync();
            string filePath = "";

            if (record != null)
            {
                if (slider.Image != null)
                {
                    var path = "wwwroot" + record.SliderImage;
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "slider");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + slider.Image.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await slider.Image.CopyToAsync(fileStream);
                    }
                    filePath = "/slider/" + uniqueFileName;
                }
                record.SliderImage = filePath;
                record.OrderBy = slider.OrderBy;
                record.IsActive = slider.IsActive;
                record.CreatedAt = slider.CreatedAt;
                record.CreatedBy = slider.CreatedBy;
                record.LastUpdatedBy = slider.LastUpdatedBy;
                record.LastUpdatedAt = DateTime.UtcNow;
                record.IsDeleted = false;
                record.IsActive = slider.IsActive;
                _appDbcontext.Slider.Update(record);
                await _appDbcontext.SaveChangesAsync();
            }
            return slider;
        }
        public async Task<Slider> DeleteAsync(int Id)
        {
            var slider = await _appDbcontext.Slider.Where(sd => sd.SliderId == Id).FirstOrDefaultAsync();
            if (slider != null)
            {
                var path = "wwwroot" + slider.SliderImage;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                _appDbcontext.Slider.Remove(slider);
                await _appDbcontext.SaveChangesAsync();
            }
            return slider;
        }
    }
}
