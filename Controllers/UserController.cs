﻿using ERP.Interface;
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
        [HttpGet]
        [Route("get")]
        public async Task <IEnumerable<Users>> Get()
        {
           return await _userRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Users> GetById(int Id)
        {
            return await _userRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("add")]
        public async Task<Users> UserAdd(Users user) 
        {
            return await _userRepository.AddAsync(user);
        }
        [HttpPut]
        [Route("update")]
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
        [HttpGet]
        [Route("login")]
        public async Task<UserSignUpResponse> UserLogin(Users user)
        {
            return await _userRepository.LogInAsync(user);
        }
        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<Users>> Search(UserSearch userSearch)
        {
            return await _userRepository.SearchAsync(userSearch);
        }
    }
}