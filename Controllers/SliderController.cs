using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISlider _sliderRepository;
        public SliderController(ISlider sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Slider>> Get()
        {
            return await _sliderRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Slider> GetById(int Id)
        {
            return await _sliderRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Slider> SliderAdd(IFormCollection obj)
        {
                var slider = new Slider()
                {
                    SliderId = 0,
                    Image = obj.Files["Image"],
                    OrderBy = Convert.ToInt32(obj["OrderBy"]),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = Convert.ToInt32(obj["CreatedBy"]),
                    //LastUpdatedAt = DateTime.UtcNow,
                    ////LastUpdatedBy = Convert.ToInt32(obj["LastUpdatedBy"]),
                };
                return await _sliderRepository.AddAsync(slider);
        }
        [HttpPost]
        [Route("put")]
        public async Task<Slider> SliderUpdate(IFormCollection obj)
        {
            var slider = new Slider()
            {
                SliderId = Convert.ToInt32(obj["SliderId"]),
                Image = obj.Files["Image"],
                OrderBy = Convert.ToInt32(obj["OrderBy"]),
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Convert.ToInt32(obj["CreatedBy"]),
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = Convert.ToInt32(obj["LastUpdatedBy"]),
            };
            return await _sliderRepository.UpdateAsync(slider);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<Slider> SliderDelete(int Id)
        {
            return await _sliderRepository.DeleteAsync(Id);
        }
    }
}
