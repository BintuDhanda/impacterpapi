﻿using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class UserRoleRepository : IUserRole
    {
        private readonly AppDbContext _appDbContext;
        public UserRoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _appDbContext.UserRole.ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _appDbContext.UserRole.FindAsync(id);
        }
        public async Task<IEnumerable<UserRole>> GetByUserIdAsync (int UserId)
        {
            var userRole = await (from allUserRole in _appDbContext.UserRole
                            join users in _appDbContext.Users on allUserRole.UserID equals users.UsersId
                            join roles in _appDbContext.Roles on allUserRole.RoleID equals roles.RolesId
                            where allUserRole.UserID == UserId
                            select new UserRole
                            {
                                UserRoleId = allUserRole.UserRoleId,
                                UserID = allUserRole.UserID,
                                RoleID = allUserRole.RoleID,
                                IsActive = allUserRole.IsActive,
                                IsDeleted = allUserRole.IsDeleted,
                                CreatedAt = allUserRole.CreatedAt,
                                CreatedBy = allUserRole.CreatedBy,
                                RoleName = roles.RoleName
                            }).ToListAsync();
            return userRole;
        }
        public async Task<UserRole> AddAsync(UserRole userRole)
         {
            var userRoles = await _appDbContext.UserRole.Where(x => x.UserID == userRole.UserID && x.RoleID == userRole.RoleID).FirstOrDefaultAsync();
            if (userRoles == null)
            {
                userRole.CreatedAt = DateTime.UtcNow;
                userRole.IsDeleted = false;
                _appDbContext.UserRole.Add(userRole);
            await _appDbContext.SaveChangesAsync();
            return userRole;
            }
            return userRoles;
        }

        public async Task<UserRole> UpdateAsync(UserRole userRole)
        {
            var userRoles = await _appDbContext.UserRole.Where(x => x.UserID == userRole.UserID && x.RoleID == userRole.RoleID).FirstOrDefaultAsync();
            if (userRoles == null)
            {
                userRole.IsDeleted = false;
                _appDbContext.UserRole.Update(userRole);
                await _appDbContext.SaveChangesAsync();
                return userRole;
            }
            return userRoles;
        }

        public async Task<UserRole> DeleteAsync(int Id)
        {
            var userRole = await _appDbContext.UserRole.FindAsync(Id);
            _appDbContext.UserRole.Remove(userRole);
            await _appDbContext.SaveChangesAsync();
            return userRole;
        }
    }
}
