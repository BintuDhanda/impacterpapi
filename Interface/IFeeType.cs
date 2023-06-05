using ERP.Models;

namespace ERP.Interface
{
    public interface IFeeType
    {
        Task<IEnumerable<FeeType>> GetAllAsync();
        Task<FeeType> GetByIdAsync(int Id);
        Task<FeeType> AddAsync(FeeType feeType);
        Task<FeeType> UpdateAsync(FeeType feeType);
        Task<FeeType> DeleteAsync(int Id);
    }
}
