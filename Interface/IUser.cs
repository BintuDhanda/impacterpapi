﻿using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface IUser
    {
        Task<IEnumerable<Users>> GetAllAsync(CommonSearchFilter commonSearchFilter);
        Task<Users> GetByIdAsync(int Id);
        Task <Users> AddAsync(Users user);
        Task <Users> UpdateAsync(Users user);
        Task <Users> DeleteAsync(int Id);
        Task<UserSignUpResponse> SignUpAsync(Users user);
        Task<UserSignUpResponse> UserLogInAsync(UserLogin userLogin);
        Task<UserSignUpResponse> ERPLogInAsync(UserLogin userLogin);
        Task<IEnumerable<Users>> SearchAsync(UserSearch userSearch);
        Task<IActionResult> IsExists(CommonSearchFilter commonSearchFilter);
        Task<IActionResult> IsVerified(string userMobile);
        Task<IActionResult> IsMobileConfirmed(string userMobile);
        Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword);
        Task<IActionResult> BulkUserUpload(FileUpload fileUpload);
        Task<IActionResult> GetStudentIdByUserId(int UserId);
        Task<IEnumerable<UserSendNotification>> GetAllNotificationAsync(CommonSearchFilter commonSearchFilter);
        Task<UserNotification> AddAsync(UserNotification userNotification);
        Task<UserNotification> UserNotificationDeleteAsync(int Id);
        Task<UserDeviceToken> UserDeviceTokenAddAsync(UserDeviceToken userDeviceToken);
    }
}
