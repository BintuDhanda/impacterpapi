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
            _dbContext.Country.Add(country);
            await _dbContext.SaveChangesAsync();
            return  country;
        }

        public async Task<Country> DeleteAsync(int Id)
        {
            var country = await _dbContext.Country.FindAsync(Id);
            _dbContext.Country.Remove(country);
            _dbContext.SaveChanges();
            return country;
        }

        public async Task<Country> UpdateAsync(Country country)
        {
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
