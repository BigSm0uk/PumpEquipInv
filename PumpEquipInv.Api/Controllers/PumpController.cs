using Microsoft.AspNetCore.Mvc;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Interfaces;

namespace PumpEquipInv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpController(IPumpRepository repository) : ControllerBase
    {
        // GET: api/<PumpController>
        [HttpGet]
        public async Task<IEnumerable<Pump>?> GetAll()
        {
            return await repository.GetAllAsync();
        }

        // GET api/<PumpController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpGet("{id:guid}")]
        public async Task<Pump?> Get(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        // POST api/<PumpController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] PumpDto item )
        {
            return await repository.CreateAsync(item);
        }

        // PUT api/<PumpController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpPut("{id:guid}")]
        public async Task<OperationResult> Put(Guid id, [FromBody] PumpDto item )
        {
            return await repository.UpdateByIdAsync(id, item);
        }

        // DELETE api/<PumpController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpDelete("{id:guid}")]
        public async Task<OperationResult> Delete(Guid id)
        {
            return await repository.DeleteByIdAsync(id);
        }
    }
}
