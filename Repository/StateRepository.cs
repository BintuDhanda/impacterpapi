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
            var states = await _appDbContext.State.Where(a => a.StateName == state.StateName).FirstOrDefaultAsync();
            if (states == null)
            {
            state.CreatedAt = DateTime.UtcNow;
            state.IsDeleted = false;
            _appDbContext.State.Add(state);
            await _appDbContext.SaveChangesAsync();
            return state;
            }
            return states;
        }

        public async Task<State> UpdateAsync(State state)
        {
            var isExist = await _appDbContext.State.Where(a => a.StateName == state.StateName && a.StateId != state.StateId).AnyAsync();
            if (!isExist)
            {
                var states = await _appDbContext.State.Where(a => a.StateId == state.StateId).FirstOrDefaultAsync();
                if (states != null)
                {
                    states.LastUpdatedAt = DateTime.UtcNow;
                    states.IsDeleted = false;
                    states.StateName = state.StateName;
                    states.LastUpdatedBy = state.LastUpdatedBy;
                    _appDbContext.State.Update(states);
                    await _appDbContext.SaveChangesAsync();
                    return states;
                }
            }
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
