using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendance _attendanceRepository;
        public AttendanceController(IAttendance attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        [HttpPost]
        [Route("getAttendanceByStudentId")]
        public async Task<IEnumerable<Attendance>> Get(int StudentId, CommonSearchFilter commonSearchFilter)
        {
            return await _attendanceRepository.GetAttendanceByStudentIdAsync(StudentId, commonSearchFilter);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Attendance> GetById(int Id)
        {
            return await _attendanceRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Attendance> AttendanceAdd(Attendance attendance)
        {
            return await _attendanceRepository.AddAsync(attendance);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Attendance> AttendanceUpdate(Attendance attendance)
        {
            return await _attendanceRepository.UpdateAsync(attendance);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Attendance> AttendanceDelete(int Id)
        {
            return await _attendanceRepository.DeleteAsync(Id);
        }
    }
}
