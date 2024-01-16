using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelRoomController : ControllerBase
    {
        private readonly IHostelRoom _repository;
        public HostelRoomController(IHostelRoom repsitory)
        {
            _repository = repsitory;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<HostelRoom>> Get(int Id)
        {
            return await _repository.GetAllAsync(Id);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<HostelRoom> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<HostelRoom> HostelRoomAdd(HostelRoom payload)
        {
            return await _repository.AddAsync(payload);
        }
        [HttpPost]
        [Route("put")]
        public async Task<HostelRoom> HostelRoomUpdate(HostelRoom payload)
        {
            return await _repository.UpdateAsync(payload);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<HostelRoom> HostelRoomDelete(int Id)
        {
            return await _repository.DeleteAsync(Id);
        }
    }
}
