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
            country.CreatedAt = DateTime.UtcNow;
            country.IsDeleted = false;
            _dbContext.Country.Add(country);
            await _dbContext.SaveChangesAsync();
            return  country;
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
            country.LastUpdatedAt = DateTime.UtcNow;
            country.IsDeleted = false;
            _dbContext.Country.Update(country);
            await _dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<Country> GetByIdAsync(int Id)
        {
            return await _dbContext.Country.FindAsync(Id);
        }
    }
}
