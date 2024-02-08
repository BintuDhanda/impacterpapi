using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademyController : ControllerBase
    {
        private readonly IAcademy _repository;
        public AcademyController(IAcademy repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Academy>> Get()
        {
            return await _repository.GetAllAsync();
        }
    }
}
