using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoard _boardRepository;
        public BoardController(IBoard boardRepository)
        {
            _boardRepository = boardRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Board>> Get()
        {
            return await _boardRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task<Board> GetById(int Id)
        {
            return await _boardRepository.GetByIdAsync(Id);
        }
        [HttpPost]
        [Route("add")]
        public async Task<Board> BoardAdd(Board board)
        {
            return await _boardRepository.AddAsync(board);
        }
        [HttpPut]
        [Route("put")]
        public async Task<Board> BoardUpdate(Board board)
        {
            return await _boardRepository.UpdateAsync(board);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<Board> BoardDelete(int Id)
        {
            return await _boardRepository.DeleteAsync(Id);
        }
    }
}
