﻿using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole _userRoleRepository;
        public UserRoleController(IUserRole userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        [HttpPost]
        [Route("add")]
        public async Task<UserRole> Add(UserRole userRole)
        {
            return await _userRoleRepository.AddAsync(userRole);
        }
        [HttpPut]
        [Route("update")]
        public async Task<UserRole> Update(UserRole userRole)
        {
            return await _userRoleRepository.UpdateAsync(userRole);
        }
        [HttpGet]
        [Route("getByUserId")]
        public async Task<IEnumerable<UserRole>> GetByUserIdAsync (int UserId)
        {
            return  await _userRoleRepository.GetByUserIdAsync(UserId);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<UserRole> DeleteAsync (int Id)
        {
            return await _userRoleRepository.DeleteAsync(Id);
        }
    }
}