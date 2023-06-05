using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCategoryController : ControllerBase
    {
        private readonly IAccountCategory _accountCategoryRepository;
        public AccountCategoryController(IAccountCategory accountCategory)
        {
            _accountCategoryRepository = accountCategory;
        }
        [HttpGet]
        [Route("get")]
        public async Task <IEnumerable<AccountCategory>> Get()
        {
            return await _accountCategoryRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<AccountCategory> GetById(int Id)
        {
            return await _accountCategoryRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<AccountCategory> AccountCategoryAdd(AccountCategory accountCategory)
        {
            return await _accountCategoryRepository.AddAsync(accountCategory);
        }
        [HttpPut]
        [Route("put")]
        public async Task<AccountCategory> AccountCategoryUpdate(AccountCategory accountCategory)
        {
            return await _accountCategoryRepository.UpdateAsync(accountCategory);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<AccountCategory> AccountCategoryDelete(int Id)
        {
            return await _accountCategoryRepository.DeleteAsync(Id);
        }
    }
}
