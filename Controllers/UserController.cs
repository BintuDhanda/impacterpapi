using ERP.Bussiness;
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
        [HttpPost]
        [Route("put")]
        public async Task<Users> UserUpdate(Users user)
        {
            return await _userRepository.UpdateAsync(user);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<Users> UserDelete(int id) 
        {
            return await _userRepository.DeleteAsync(id);
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<UserSignUpResponse> UserSignUp(Users user)
        {
            return await _userRepository.SignUpAsync(user);
        }
        [HttpPost]
        [Route("userlogin")]
        public async Task<UserSignUpResponse> UserLogin(UserLogin userLogin)
        {
            return await _userRepository.UserLogInAsync(userLogin);
        }
        [HttpPost]
        [Route("ERPlogin")]
        public async Task<UserSignUpResponse> ERPLogin(UserLogin userLogin)
        {
            return await _userRepository.ERPLogInAsync(userLogin);
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
        [HttpGet]
        [Route("getStudentIdByUserId")]
        public async Task<IActionResult> GetStudentIdByUserId(int UserId)
        {
            return await _userRepository.GetStudentIdByUserId(UserId);
        }
        [HttpGet]
        [Route("IsVerified")]
        public async Task<IActionResult> IsVerified(string userMobile)
        {
            return await _userRepository.IsVerified(userMobile);
        }
        [HttpGet]
        [Route("IsMobileConfirmed")]
        public async Task<IActionResult> IsMobileConfirmed(string userMobile)
        {
            return await _userRepository.IsMobileConfirmed(userMobile);
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            return await _userRepository.ForgotPassword(forgotPassword);
        }
        [HttpPost]
        [Route("BulkUserUpload")]
        public async Task<IActionResult> BulkUserUpload([FromForm] FileUpload fileUpload)
        {
            return await _userRepository.BulkUserUpload(fileUpload);
        }
        [HttpPost]
        [Route("getAllNotification")]
        public async Task<IEnumerable<UserSendNotification>> GetAllNotification(CommonSearchFilter commonSearchFilter)
        {
            return await _userRepository.GetAllNotificationAsync(commonSearchFilter);
        }
        [HttpPost]
        [Route("UserNotification")]
        public async Task<UserNotification> UserNotificationAdd ([FromBody] UserNotification userNotification)
        {
            return await _userRepository.AddAsync(userNotification);
        }
        [HttpGet]
        [Route("UserNotificationDelete")]
        public async Task<UserNotification> UserNotificationDelete (int Id)
        {
            return await _userRepository.UserNotificationDeleteAsync(Id);
        }
        [HttpPost]
        [Route("UserDeviceToken")]
        public async Task<UserDeviceToken> UserDeviceTokenAdd([FromBody] UserDeviceToken userDeviceToken)
        {
            return await _userRepository.UserDeviceTokenAddAsync(userDeviceToken);
        }
    }
}
