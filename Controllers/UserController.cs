using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;
namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;
        public UserController(IUser user)
        {
            _userRepository = user;
        }
        [HttpPost]
        [Route("get")]
        public async Task <IEnumerable<Users>> Get(CommonSearchFilter commonSearchFilter)
        {
           return await _userRepository.GetAllAsync(commonSearchFilter);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Users> GetById(int Id)
        {
            return await _userRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Users> UserAdd(Users user) 
        {
            return await _userRepository.AddAsync(user);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Users> UserUpdate(Users user)
        {
            return await _userRepository.UpdateAsync(user);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Users> UserDelete(int id) 
        {
            return await _userRepository.DeleteAsync(id);
        }

        [HttpGet]
        [Route("signUp")]
        public async Task<UserSignUpResponse> UserSignUp(Users user)
        {
            return await _userRepository.SignUpAsync(user);
        }
        [HttpPost]
        [Route("login")]
        public async Task<UserSignUpResponse> UserLogin(UserLogin userLogin)
        {
            return await _userRepository.LogInAsync(userLogin);
        }
        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<Users>> Search(UserSearch userSearch)
        {
            return await _userRepository.SearchAsync(userSearch);
        }
        [HttpPost]
        [Route("IsExists")]
        public async Task<IActionResult> IsExists([FromBody] CommonSearchFilter commonSearchFilter)
        {
            return await _userRepository.IsExists(commonSearchFilter);
        }
        [HttpPost]
        [Route("IsVerified")]
        public async Task<IActionResult> IsVerified(string userMobile)
        {
            return await _userRepository.IsVerified(userMobile);
        }
        [HttpPost]
        [Route("IsMobileConfirmed")]
        public async Task<IActionResult> IsMobileConfirmed(string userMobile)
        {
            return await _userRepository.IsMobileConfirmed(userMobile);
        }
    }
}
