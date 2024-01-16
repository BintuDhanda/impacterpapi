using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelController : ControllerBase
    {
        private readonly IHostel _repository;
        public HostelController(IHostel repsitory)
        {
            _repository = repsitory;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Hostel>> Get()
        {
            return await _repository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Hostel> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Hostel> HostelAdd(Hostel payload)
        {
            return await _repository.AddAsync(payload);
        }
        [HttpPost]
        [Route("put")]
        public async Task<Hostel> HostelUpdate(Hostel payload)
        {
            return await _repository.UpdateAsync(payload);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<Hostel> HostelDelete(int Id)
        {
            return await _repository.DeleteAsync(Id);
        }
    }
}
