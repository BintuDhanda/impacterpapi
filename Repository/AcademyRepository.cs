using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class AcademyRepository : IAcademy
    {
        private readonly AppDbContext _appDbcontext;
        public AcademyRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        public async Task<IEnumerable<Academy>> GetAllAsync()
        {
            return await _appDbcontext.Academies.ToListAsync();
        }
    }
}
