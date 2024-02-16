using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class CountryRepository : ICountry
    {
        private readonly AppDbContext _dbContext;
        public CountryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _dbContext.Country.ToListAsync();
        }
        public async Task<Country> AddAsync(Country country)
        {
            var countrys = await _dbContext.Country.Where(c => c.CountryName == country.CountryName).FirstOrDefaultAsync();
            if (countrys == null)
            {
                country.CreatedAt = DateTime.UtcNow;
                country.IsDeleted = false;
                _dbContext.Country.Add(country);
                await _dbContext.SaveChangesAsync();
                return country;
            }
            return countrys;
        }

        public async Task<Country> DeleteAsync(int Id)
        {
            var country = await _dbContext.Country.FindAsync(Id);
            _dbContext.Country.Remove(country);
            await _dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<Country> UpdateAsync(Country country)
        {
            var isExist = await _dbContext.Country.Where(c => c.CountryName == country.CountryName && c.CountryId != country.CountryId).AnyAsync();
            if (!isExist)
            {
                var countrys = await _dbContext.Country.Where(c => c.CountryId == country.CountryId).FirstOrDefaultAsync();
                if (countrys != null)
                {
                    countrys.LastUpdatedAt = DateTime.UtcNow;
                    countrys.IsDeleted = false;
                    countrys.CountryName = country.CountryName;
                    countrys.LastUpdatedBy = country.LastUpdatedBy;
                    _dbContext.Country.Update(countrys);
                    await _dbContext.SaveChangesAsync();
                    return countrys;
                }
            }
            return country;
        }

        public async Task<Country> GetByIdAsync(int Id)
        {
            return await _dbContext.Country.FindAsync(Id);
        }
    }
}
