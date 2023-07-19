using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountRepository;
        public AccountController(IAccount accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Account>> Get()
        {
            return await _accountRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Account> GetById(int Id)
        {
            return await _accountRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Account> AccountAdd(Account account)
        {
            return await _accountRepository.AddAsync(account);
        }
        [HttpPost]
        [Route("put")]
        public async Task<Account> AccountUpdate(Account account)
        {
            return await _accountRepository.UpdateAsync(account);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<Account> AccountDelete(int Id)
        {
            return await _accountRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getAccountByAccountCategoryId")]
        public async Task<IEnumerable<Account>> GetAccountByAccountCategoryId(int Id)
        {
            return await _accountRepository.GetAccountByAccountCategoryIdAsync(Id);
        }
    }
}
