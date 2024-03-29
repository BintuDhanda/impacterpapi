﻿using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class CityRepository : ICity
    {
        private readonly AppDbContext _appDbContext;
        public CityRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _appDbContext.City.ToListAsync();
        }
        public async Task<City> GetByIdAsync(int Id)
        {
            return await _appDbContext.City.FindAsync(Id);
        }
        public async Task<City> AddAsync(City city)
        {
            var citys = await _appDbContext.City.Where(c => c.CityName == city.CityName).FirstOrDefaultAsync();
            if (citys == null)
            {
                city.CreatedAt = DateTime.UtcNow;
                city.IsDeleted = false;
                _appDbContext.City.Add(city);
                await _appDbContext.SaveChangesAsync();
                return city;
            }
            return citys;
        }
        public async Task<City> UpdateAsync(City city)
        {
            var isExist = await _appDbContext.City.Where(c => c.CityName == city.CityName && c.CityId != city.CityId).AnyAsync();
            if (!isExist)
            {
                var citys = await _appDbContext.City.Where(c => c.CityId == city.CityId).FirstOrDefaultAsync();
                if (citys != null)
                {
                    citys.LastUpdatedAt = DateTime.UtcNow;
                    citys.IsDeleted = false;
                    citys.CityName = city.CityName;
                    citys.LastUpdatedBy = city.LastUpdatedBy;
                    _appDbContext.City.Update(citys);
                    await _appDbContext.SaveChangesAsync();
                    return citys;
                }
            }
            return city;
        }
        public async Task<City> DeleteAsync(int Id)
        {
            var city = await _appDbContext.City.FindAsync(Id);
            _appDbContext.City.Remove(city);
            await _appDbContext.SaveChangesAsync();
            return city;
        }
        public async Task<IEnumerable<City>> GetCityByStateIdAsync(int Id)
        {
            return await _appDbContext.City.Where(c => c.StateId == Id).ToListAsync();
        }
    }
}
