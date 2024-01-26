using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelRoomBadStudentRentController : ControllerBase
    {
        private readonly IHostelRoomBadStudentRent _repository;
        public HostelRoomBadStudentRentController(IHostelRoomBadStudentRent repsitory)
        {
            _repository = repsitory;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<HostelRoomBadStudentRent>> Get(int Id)
        {
            return await _repository.GetAllAsync(Id);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<HostelRoomBadStudentRent> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<HostelRoomBadStudentRent> HostelRoomBadStudentRentAdd(HostelRoomBadStudentRent payload)
        {
            return await _repository.AddAsync(payload);
        }
        [HttpPost]
        [Route("put")]
        public async Task<HostelRoomBadStudentRent> HostelRoomBadStudentRentUpdate(HostelRoomBadStudentRent payload)
        {
            return await _repository.UpdateAsync(payload);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<HostelRoomBadStudentRent> HostelRoomBadStudentRentDelete(int Id)
        {
            return await _repository.DeleteAsync(Id);
        }
    }
}
