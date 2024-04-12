using Microsoft.AspNetCore.Mvc;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Interfaces;

namespace PumpEquipInv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorController(IMotorRepository repository) : ControllerBase
    {
        // GET: api/<MotorController>
        [HttpGet]
        public async Task<IEnumerable<Motor>?> GetAll()
        {
            return await repository.GetAllAsync();
        }

        // GET api/<MotorController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpGet("{id:guid}")]
        public async Task<Motor?> Get(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        // POST api/<MotorController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] MotorDto item )
        {
            return await repository.CreateAsync(item);
        }

        // PUT api/<MotorController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpPut("{id:guid}")]
        public async Task<OperationResult> Put(Guid id, [FromBody] MotorDto item )
        {
            return await repository.UpdateByIdAsync(id, item);
        }

        // DELETE api/<MotorController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpDelete("{id:guid}")]
        public async Task<OperationResult> Delete(Guid id)
        {
            return await repository.DeleteByIdAsync(id);
        }
    }
}
