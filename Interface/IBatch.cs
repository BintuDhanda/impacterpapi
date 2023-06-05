using ERP.Models;

namespace ERP.Interface
{
    public interface IBatch
    {
        Task<IEnumerable<Batch>> GetAllAsync();
        Task<Batch> GetByIdAsync(int id);
        Task<Batch> AddAsync(Batch batch);
        Task<Batch> UpdateAsync(Batch batch);
        Task<Batch> DeleteAsync(int id);
        Task<IEnumerable<Batch>> GetBatchByCourseIdAsync (int Id);
    }
}
