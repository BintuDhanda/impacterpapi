using ERP.Bussiness;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
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
        [HttpPost]
        [Route("get")]
        public async Task<IEnumerable<DayBook>> Get([FromBody] CommonSearchFilter commonSearchFilter)
        {
            return await _dayBookRepository.GetAllAsync(commonSearchFilter);
        }
        [HttpPost]
        [Route("getDayBookByAccountId")]
        public async Task<IEnumerable<DayBook>> GetDayBookByAccountId(AccountSearchFilter accountSearchFilter)
        {
            return await _dayBookRepository.GetDayBookByAccountIdAsync(accountSearchFilter);
        }
        [HttpPost]
        [Route("post")]
        public async Task<DayBook> DayBookAdd(DayBook dayBook)
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
        [HttpPost]
        [Route("sumCreditAndDebit")]
        public async Task<IActionResult> SumCreditAndDebit(SumCreditAndDebitDaybook sumCreditAndDebitDaybook)
        {
            return await _dayBookRepository.SumCreditAndDebitAsync(sumCreditAndDebitDaybook);
        }
    }
}
