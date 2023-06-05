using ERP.Models;

namespace ERP.Interface
{
    public interface IQualification
    {
        Task<IEnumerable<Qualification>> GetAllAsync();
        Task<Qualification> GetByIdAsync(int Id);
        Task<Qualification> AddAsync(Qualification qualification);
        Task<Qualification> UpdateAsync(Qualification qualification);
        Task<Qualification> DeleteAsync(int Id);
    }
}
