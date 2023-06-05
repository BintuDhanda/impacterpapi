using ERP.Models;

namespace ERP.Interface
{
    public interface IState
    {
        Task<IEnumerable<State>> GetAllAsync();
        Task<State> GetByIdAsync(int Id);
        Task<State> AddAsync(State state);
        Task<State> UpdateAsync(State state);
        Task<State> DeleteAsync(int Id);
        Task<IEnumerable<State>> GetStateByCountryIdAsync(int Id);
    }
}
