﻿using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP.Bussiness
{
    public  class UserRepository : IUser
    {
        public IConfiguration _configration;
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext appDbContext,IConfiguration configuration)
        {
            _dbContext = appDbContext;
            _configration = configuration;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _dbContext.Users.OrderByDescending(o=>o.Id).Take(10).ToListAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<Users> AddAsync(Users user)
        {
            user.CreatedAt = DateTime.UtcNow;
            var users = await _dbContext.Users.Where(x=>x.UserName == user.UserName || x.PhoneNumber == user.PhoneNumber).FirstOrDefaultAsync();
            if (users == null)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }

            return users;
        }

        public async Task<Users> UpdateAsync(Users user)
        {
            var record = await _dbContext.Users.Where(w => w.Id == user.Id).FirstOrDefaultAsync();
            record.IsActive = user.IsActive;
            record.UserPassword = user.UserPassword;
            record.UserName = user.UserName;
            record.PhoneNumber = user.PhoneNumber;
            _dbContext.Users.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<Users> DeleteAsync(int Id)
        {
            var user = await  _dbContext.Users.FindAsync(Id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserRole> AddUserToRole(Users user)
        {
            var roleId = await _dbContext.Roles.Where(r=>r.RoleName=="Student").Select(s=>s.Id).FirstOrDefaultAsync();

            var userRole = new UserRole()
            {
                RoleID = roleId,
                UserID = user.Id
            };
             _dbContext.UserRole.Add(userRole);
            await _dbContext.SaveChangesAsync();
            return userRole;
        }
        public async Task<UserSignUpResponse> SignUpAsync(Users user)
        {
            var newUser = AddAsync(user).Result;
            var userRole = AddUserToRole(user).Result;
            var response = GenerateJWT(newUser);
            return response;
        }

        public async Task<IEnumerable<Users>> SearchAsync(UserSearch userSearch)
        {
            int currentPage = userSearch.CurrentPage;
            int recordsPerPage = userSearch.Take;
            int skip = userSearch.CurrentPage==1? 0: (userSearch.CurrentPage-1)*userSearch.Take;


            var count =  await _dbContext.Users.Where(w =>
               (string.IsNullOrEmpty(userSearch.UserName) || w.UserName.Contains(userSearch.UserName))
               && (string.IsNullOrEmpty(userSearch.PhoneNumber) || w.PhoneNumber.Contains(userSearch.PhoneNumber))
               && (string.IsNullOrEmpty(userSearch.IsActive) || w.IsActive == Convert.ToBoolean(userSearch.IsActive))
               && (string.IsNullOrEmpty(userSearch.From) && string.IsNullOrEmpty(userSearch.To) && !w.CreatedAt.HasValue) || w.CreatedAt.Value.Date >= Convert.ToDateTime(userSearch.From) || w.CreatedAt <= Convert.ToDateTime(userSearch.To)
               ).Select(s=>s.Id).CountAsync(); 

            var users = await _dbContext.Users.Where(w =>
               (string.IsNullOrEmpty(userSearch.UserName) || w.UserName.Contains(userSearch.UserName))
               && (string.IsNullOrEmpty(userSearch.PhoneNumber) || w.PhoneNumber.Contains(userSearch.PhoneNumber))
               && (string.IsNullOrEmpty(userSearch.IsActive)||w.IsActive == Convert.ToBoolean(userSearch.IsActive))
               && (string.IsNullOrEmpty(userSearch.From) && string.IsNullOrEmpty(userSearch.To) && !w.CreatedAt.HasValue ) ||  w.CreatedAt.Value.Date >= Convert.ToDateTime(userSearch.From) || w.CreatedAt <= Convert.ToDateTime(userSearch.To)
               ).Take(userSearch.Take).
               Skip(skip)
               .Select(s=>new Users
               {
                    CreatedAt = s.CreatedAt.HasValue?s.CreatedAt.Value.Date: null,
                     Id=s.Id,
                      IsActive=s.IsActive.HasValue?s.IsActive.Value: null,
                      UserName=s.UserName,
                      PhoneNumber=s.PhoneNumber,
                      UserPassword= "",
                      TotalCount=count
               }).
               ToListAsync();

            return users;
        }

        public async Task<UserSignUpResponse> LogInAsync(Users user)
        {
            var userRecord = await _dbContext.Users.Where(x=>x.PhoneNumber==user.PhoneNumber || x.UserName == user.UserName && x.UserPassword == user.UserPassword).FirstOrDefaultAsync();
            if (userRecord!=null)
            {
            var response = GenerateJWT(userRecord);
            return response;
            }
            else
            {
                return new UserSignUpResponse();
            }
        }

        private UserSignUpResponse GenerateJWT(Users user)
        {
            var roleList = string.Join(',',(from ur in _dbContext.UserRole join
                           r in _dbContext.Roles on ur.RoleID equals r.Id
                           where ur.UserID == user.Id
                           select r.RoleName));

            var issuer = _configration["Jwt:Issuer"];
            var audience = _configration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Phone", user.PhoneNumber),
                    new Claim("Role", roleList),
             }),
                Expires = DateTime.UtcNow.AddDays(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            var userSignUpResponse = new UserSignUpResponse()
            {
                Message = "success",
                Token = jwtToken,
                UserId = user.Id,
            };

            return userSignUpResponse;
        }
        
    }
}