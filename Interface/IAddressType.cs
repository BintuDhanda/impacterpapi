using ERP.Models;

namespace ERP.Interface
{
    public interface IAddressType
    {
        Task<IEnumerable<AddressType>> GetAllAsync();
        Task<AddressType> GetByIdAsync(int Id);
        Task<AddressType> AddAsync(AddressType address);
        Task<AddressType> UpdateAsync(AddressType address);
        Task<AddressType> DeleteAsync(int Id);
    }
}
