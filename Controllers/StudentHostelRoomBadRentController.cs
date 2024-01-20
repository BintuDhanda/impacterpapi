using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentHostelRoomBadRentController : ControllerBase
    {
        private readonly IStudentHostelRoomBadRent _repository;
        public StudentHostelRoomBadRentController(IStudentHostelRoomBadRent repsitory)
        {
            _repository = repsitory;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentHostelRoomBadRent>> Get(int id)
        {
            return await _repository.GetAllAsync(id);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentHostelRoomBadRent> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }
    }
}
