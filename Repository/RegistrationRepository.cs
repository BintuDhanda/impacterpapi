using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class RegistrationRepository:IRegistration
    {
        private readonly AppDbContext _appDbContext;
        public RegistrationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Registration>> GetAllAsync()
        {
            return await _appDbContext.Registration.ToListAsync();
        }
        public async Task<Registration> GetByIdAsync(int Id)
        {
            return await _appDbContext.Registration.FindAsync(Id);
        }
        public async Task<Registration> AddAsync(Registration registration)
        {
           _appDbContext.Registration.Add(registration);
            await _appDbContext.SaveChangesAsync();
            return registration;
        }
        public async Task<Registration> UpdateAsync(Registration registration)
        {
            _appDbContext.Registration.Update(registration);
            await _appDbContext.SaveChangesAsync();
            return registration;
        }
        public async Task<Registration> DeleteAsync(int Id)
        {
            var registration = await _appDbContext.Registration.FindAsync(Id);
            _appDbContext.Registration.Remove(registration);
            await _appDbContext.SaveChangesAsync();
            return registration;
        }
    }
}
