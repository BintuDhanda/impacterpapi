using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatch _batchRepsitory;
        public BatchController (IBatch batchRepsitory)
        {
            _batchRepsitory= batchRepsitory;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Batch>> Get()
        {
            return await _batchRepsitory.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Batch> GetById(int Id)
        {
            return await _batchRepsitory.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("post")]
        public async Task<Batch> BatchAdd(Batch batch)
        {
            return await _batchRepsitory.AddAsync(batch);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Batch> BatchUpdate(Batch batch)
        {
            return await _batchRepsitory.UpdateAsync(batch);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Batch> BatchDelete(int Id)
        {
            return await _batchRepsitory.DeleteAsync(Id);
        }
        [HttpGet]
        [Route("getBatchByCourseId")]
        public async Task<IEnumerable<Batch>> GetBatchByCourseId(int Id)
        {
            return await _batchRepsitory.GetBatchByCourseIdAsync(Id);
        }
    }
}
