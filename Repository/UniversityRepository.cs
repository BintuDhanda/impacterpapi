using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class UniversityRepository : IUniversity
    {
        private readonly AppDbContext _appDbContext;
        public UniversityRepository(AppDbContext apDbContext)
        {
            _appDbContext = apDbContext;
        }
        public async Task<IEnumerable<University>> GetAllAsync()
        {
            return await _appDbContext.University.ToListAsync();
        }
        public async Task<University> GetByIdAsync(int Id)
        {
            return await _appDbContext.University.FindAsync(Id);
        }
        public async Task<University> AddAsync(University university)
        {
            _appDbContext.University.Add(university);
            await _appDbContext.SaveChangesAsync();
            return university;
        }
        public async Task<University> UpdateAsync(University university)
        {
            _appDbContext.University.Update(university);
            await _appDbContext.SaveChangesAsync();
            return university;
        }
        public async Task<University> DeleteAsync(int Id)
        {
            var university = await _appDbContext.University.FindAsync(Id);
            _appDbContext.University.Remove(university);
            await _appDbContext.SaveChangesAsync();
            return university;
        }
    }
}
