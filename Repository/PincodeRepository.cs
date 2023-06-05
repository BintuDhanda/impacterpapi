using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class PincodeRepository : IPincode
    {
        private readonly AppDbContext _appdbcontext;
        public PincodeRepository(AppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }

        public async Task<Pincode> AddAsync(Pincode pincode)
        {
            _appdbcontext.Pincode.Add(pincode);
            await _appdbcontext.SaveChangesAsync();
            return pincode;
        }

        public async Task<Pincode> DeleteAsync(int Id)
        {
            var pincode = await _appdbcontext.Pincode.FindAsync(Id);
            _appdbcontext.Pincode.Remove(pincode);
            await _appdbcontext.SaveChangesAsync();
            return pincode;

        }

        public async Task<IEnumerable<Pincode>> GetAllAsync()
        {
            return await _appdbcontext.Pincode.ToListAsync();
        }

        public async Task<Pincode> GetByIdAsync(int Id)
        {
            return await _appdbcontext.Pincode.FindAsync(Id);
        }

        public async Task<Pincode> UpdateAsync(Pincode pincode)
        {
            _appdbcontext.Pincode.Update(pincode);
            await _appdbcontext.SaveChangesAsync();
            return pincode;
        }
    }
}
