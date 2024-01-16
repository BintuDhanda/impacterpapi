using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelRoomBadController : ControllerBase
    {
        private readonly IHostelRoomBad _repository;
        public HostelRoomBadController(IHostelRoomBad repsitory)
        {
            _repository = repsitory;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<HostelRoomBad>> Get(int Id)
        {
            return await _repository.GetAllAsync(Id);
        }
        [HttpGet]
        [Route("getUnallocated")]
        public async Task<IEnumerable<HostelRoomBad>> GetUnallocated(int Id)
        {
            return await _repository.GetAllUnallocatedAsync(Id);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<HostelRoomBad> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<HostelRoomBad> HostelRoomBadAdd(HostelRoomBad payload)
        {
            return await _repository.AddAsync(payload);
        }
        [HttpPost]
        [Route("put")]
        public async Task<HostelRoomBad> HostelRoomBadUpdate(HostelRoomBad payload)
        {
            return await _repository.UpdateAsync(payload);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<HostelRoomBad> HostelRoomBadDelete(int Id)
        {
            return await _repository.DeleteAsync(Id);
        }
    }
}
