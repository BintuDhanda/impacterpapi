using ERP.Models;

namespace ERP.Interface
{
    public interface IPincode
    {
        Task <IEnumerable<Pincode>> GetAllAsync();
        Task<Pincode> GetByIdAsync (int Id);
        Task<Pincode> AddAsync(Pincode pincode);
        Task<Pincode> UpdateAsync(Pincode pincode);
        Task<Pincode> DeleteAsync(int Id);
    }
}
