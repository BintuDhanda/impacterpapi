using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class TokenValidityRepository:ITokenValidity
    {
        private readonly AppDbContext _appDbContext;
        public TokenValidityRepository(AppDbContext apDbContext)
        {
            _appDbContext = apDbContext;
        }
        public async Task<IEnumerable<TokenValidity>> GetAllAsync()
        {
            return await _appDbContext.TokenValidity.ToListAsync();
        }
        public async Task<TokenValidity> GetByIdAsync(int BatchId)
        {
            return await _appDbContext.TokenValidity.Where(x=>x.BatchId == BatchId).FirstOrDefaultAsync();
        }
        public async Task<TokenValidity> AddAsync(TokenValidity tokenValidity)
        {
            _appDbContext.TokenValidity.Add(tokenValidity);
            await _appDbContext.SaveChangesAsync();
            return tokenValidity;
        }
        public async Task<TokenValidity> UpdateAsync(TokenValidity tokenValidity)
        {
            _appDbContext.TokenValidity.Update(tokenValidity);
            await _appDbContext.SaveChangesAsync();
            return tokenValidity;
        }
        public async Task<TokenValidity> DeleteAsync(int Id)
        {
            var tokenValidity = await _appDbContext.TokenValidity.FindAsync(Id);
            _appDbContext.TokenValidity.Remove(tokenValidity);
            await _appDbContext.SaveChangesAsync();
            return tokenValidity;
        }
    }
}
