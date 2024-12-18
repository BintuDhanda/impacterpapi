using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class VillageRepository : IVillage
    {
        private readonly AppDbContext _appDbContext;
        public VillageRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task<IEnumerable<Village>> GetAllAsync()
        {
            return await _appDbContext.Village.ToListAsync();
        }
        public async Task<Village> GetByIdAsync(int Id)
        {
            return await _appDbContext.Village.FindAsync(Id);
        }
        public async Task<Village> AddAsync(Village city)
        {
            var citys = await _appDbContext.Village.Where(c => c.VillageName == city.VillageName).FirstOrDefaultAsync();
            if (citys == null)
            {
                city.CreatedAt = DateTime.UtcNow;
                city.IsDeleted = false;
                _appDbContext.Village.Add(city);
                await _appDbContext.SaveChangesAsync();
                return city;
            }
            return citys;
        }
        public async Task<Village> UpdateAsync(Village city)
        {
            var isExist = await _appDbContext.Village.Where(c => c.VillageName == city.VillageName && c.VillageId != city.VillageId).AnyAsync();
            if (!isExist)
            {
                var citys = await _appDbContext.Village.Where(c => c.VillageId == city.VillageId).FirstOrDefaultAsync();
                if (citys != null)
                {
                    citys.LastUpdatedAt = DateTime.UtcNow;
                    citys.IsDeleted = false;
                    citys.VillageName = city.VillageName;
                    citys.LastUpdatedBy = city.LastUpdatedBy;
                    _appDbContext.Village.Update(citys);
                    await _appDbContext.SaveChangesAsync();
                    return citys;
                }
            }
            return city;
        }
        public async Task<Village> DeleteAsync(int Id)
        {
            var city = await _appDbContext.Village.FindAsync(Id);
            _appDbContext.Village.Remove(city);
            await _appDbContext.SaveChangesAsync();
            return city;
        }
        public async Task<IEnumerable<Village>> GetVillageByCityIdAsync(int Id)
        {
            return await _appDbContext.Village.Where(c => c.CityId == Id).ToListAsync();
        }
    }
}
