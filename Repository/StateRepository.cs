using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StateRepository : IState
    {
        private readonly AppDbContext _appDbContext;
        public StateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _appDbContext.State.ToListAsync();
        }

        public async Task<State> GetByIdAsync(int Id)
        {
            return await _appDbContext.State.FindAsync(Id);
        }

        public async Task<State> AddAsync(State state)
        {
            _appDbContext.State.Add(state);
            await _appDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<State> UpdateAsync(State state)
        {
            _appDbContext.State.Update(state);
            await _appDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<State> DeleteAsync( int Id)
        {
            var state = await _appDbContext.State.FindAsync(Id);
            _appDbContext.State.Remove(state);
            await _appDbContext.SaveChangesAsync();
            return state;
        }
        public async Task<IEnumerable<State>> GetStateByCountryIdAsync(int Id)
        {
            return await _appDbContext.State.Where(s=>s.CountryId==Id).ToListAsync();
        }
    }
}
