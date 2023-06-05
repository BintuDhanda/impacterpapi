using ERP.Models;

namespace ERP.Interface
{
    public interface ITokenValidity
    {
        Task<IEnumerable<TokenValidity>> GetAllAsync();
        Task<TokenValidity> GetByIdAsync(int BatchId);
        Task<TokenValidity> AddAsync(TokenValidity tokenValidity);
        Task<TokenValidity> UpdateAsync(TokenValidity tokenValidity);
        Task<TokenValidity> DeleteAsync(int Id);
    }
}
