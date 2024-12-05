using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelRoomBadStudentController : ControllerBase
    {
        private readonly IHostelRoomBadStudent _repository;
        public HostelRoomBadStudentController(IHostelRoomBadStudent repsitory)
        {
            _repository = repsitory;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<HostelRoomBadStudent>> Get(int Id)
        {
            return await _repository.GetAllAsync(Id);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<HostelRoomBadStudent> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<HostelRoomBadStudent> HostelRoomBadStudentAdd(HostelRoomBadStudent payload)
        {
            try
            {
                return await _repository.AddAsync(payload);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 450;
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        [Route("put")]
        public async Task<HostelRoomBadStudent> HostelRoomBadStudentUpdate(HostelRoomBadStudent payload)
        {
            try
            {
                return await _repository.UpdateAsync(payload);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 450;
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("delete")]
        public async Task<HostelRoomBadStudent> HostelRoomBadStudentDelete(int Id)
        {
            return await _repository.DeleteAsync(Id);
        }
    }
}
