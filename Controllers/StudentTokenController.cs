﻿using ERP.Bussiness;
using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTokenController : ControllerBase
    {
        private readonly IStudentToken _studentTokenRepository;
        public StudentTokenController(IStudentToken studentTokenRepository)
        {
            _studentTokenRepository = studentTokenRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<List<StudentToken>> Get()
        {
            return (List<StudentToken>)await _studentTokenRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<StudentToken> GetById(int Id)
        {
            return await _studentTokenRepository.GetByIdAsync(Id);
        }
        //[HttpPost]
        //[Route("post")]
        //public async Task<StudentToken> StudentTokenAdd(int StudentId, int BatchId)
        //{
        //    return await _studentTokenRepository.AddAsync(StudentId,BatchId);
        //}
        [HttpPost]
        [Route("post")]
        public async Task<StudentToken> StudentTokenAdd(StudentToken studentToken)
        {
            studentToken.StudentId = studentToken.CreatedBy;
            return await _studentTokenRepository.AddAsync(studentToken);
        }
        [HttpPost]
        [Route("put")]
        public async Task<StudentToken> StudentTokenUpdate(StudentToken studentToken)
        {
            return await _studentTokenRepository.UpdateAsync(studentToken);
        }
        [HttpGet]
        [Route("delete")]
        public async Task<StudentToken> StudentTokenDelete(int Id)
        {
            return await _studentTokenRepository.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getStudentTokenByStudentId")]
        public async Task<IEnumerable<StudentToken>> GetStudentTokenByStudentId(int StudentId)
        {
            return await _studentTokenRepository.GetStudentTokenByStudentIdAsync(StudentId);
        }
    }
}
