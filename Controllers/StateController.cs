using ERP.Interface;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState _stateRepository;
        public StateController(IState stateRepository)
        {
            _stateRepository = stateRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task <IEnumerable<State>> Get()
        {
            return await _stateRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("getById")]
        public async Task <State> GetById(int Id)
        {
            return await _stateRepository.GetByIdAsync(Id);   
        }
        [HttpPost]
        [Route("post")]
        public async Task <State> StateAdd(State state)
        {
            return await _stateRepository.AddAsync(state);
        }
        [HttpPut]
        [Route("put")]
        public async Task <State> StateUpdate(State state)
        {
            return await _stateRepository.UpdateAsync(state);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<State> StateDelete(int Id)
        {
            return await(_stateRepository.DeleteAsync(Id));
        }
        [HttpGet]
        [Route("getStateByCountryId")]
        public async Task<IEnumerable<State>> GetStateByCountryId(int Id)
        {
            return await _stateRepository.GetStateByCountryIdAsync(Id);
        }
    }
}
