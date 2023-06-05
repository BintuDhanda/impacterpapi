using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class RoleRepository : IRole
    {
        private readonly AppDbContext _appDbContext;
        public RoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _appDbContext.Roles.ToListAsync();
        }
        public async Task<Roles> GetByIdAsync(int Id)
        {
            return await _appDbContext.Roles.FindAsync(Id);
        }
        public async Task<Roles> AddAsync(Roles role)
        {
            var roles = await _appDbContext.Roles.Where(x => x.RoleName == role.RoleName).FirstOrDefaultAsync();
            if(roles == null)
            {

            _appDbContext.Roles.Add(role);
            await _appDbContext.SaveChangesAsync();
            return role;
            }
            return roles;
        }
        public async Task<Roles> UpdateAsync(Roles role)
        {
            _appDbContext.Roles.Update(role);
            await _appDbContext.SaveChangesAsync();
            return role;
        }
        public async Task<Roles> DeleteAsync(int Id)
        {
            var role = await _appDbContext.Roles.FindAsync(Id);
             _appDbContext.Remove(role);
            await _appDbContext.SaveChangesAsync();
            return role;
        }
    }
}
