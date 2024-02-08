using ERP.Models;

namespace ERP.Interface
{
    public interface IAcademy
    {
        Task<IEnumerable<Academy>> GetAllAsync();
    }
}
