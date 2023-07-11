using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class AddressTypeRepository:IAddressType
    {
        private readonly AppDbContext _appDbContext;
        public AddressTypeRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<AddressType>> GetAllAsync()
        {
            return await _appDbContext.AddressType.ToListAsync();
        }
        public async Task<AddressType> GetByIdAsync(int Id)
        {
            return await _appDbContext.AddressType.FindAsync(Id);
        }
        public async Task<AddressType> AddAsync(AddressType addressType)
        {
            addressType.CreatedAt = DateTime.UtcNow;
            addressType.IsDeleted = false;
            _appDbContext.AddressType.Add(addressType);
            await _appDbContext.SaveChangesAsync();
            return addressType;
        }
        public async Task<AddressType> UpdateAsync(AddressType addressType)
        {
            addressType.LastUpdatedAt = DateTime.UtcNow;
            addressType.IsDeleted = false;
            _appDbContext.AddressType.Update(addressType);
            await _appDbContext.SaveChangesAsync();
            return addressType;
        }
        public async Task<AddressType> DeleteAsync(int Id)
        {
            var addressType = await _appDbContext.AddressType.FindAsync(Id);
            _appDbContext.AddressType.Remove(addressType);
            await _appDbContext.SaveChangesAsync();
            return addressType;
        }
    }
}
