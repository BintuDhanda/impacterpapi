using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayBookController : ControllerBase
    {
        private readonly IDayBook _dayBookRepository;
        public DayBookController(IDayBook dayBookRepository)
        {
            _dayBookRepository = dayBookRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<DayBook>> Get()
        {
            return await _dayBookRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<IEnumerable<DayBook>> GetById(int Id)
        {
            return await _dayBookRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<IEnumerable<DayBook>> DayBookAdd(IEnumerable<DayBook> dayBook)
        {
            return await _dayBookRepository.AddAsync(dayBook);
        }
        [HttpPut]
        [Route("put")]
        public async Task<DayBook> DayBookUpdate(DayBook dayBook)
        {
            return await _dayBookRepository.UpdateAsync(dayBook);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<DayBook> DayBookDelete(int Id)
        {
            return await _dayBookRepository.DeleteAsync(Id);
        }
    }
}
