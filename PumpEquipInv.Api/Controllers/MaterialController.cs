using Microsoft.AspNetCore.Mvc;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Interfaces;

namespace PumpEquipInv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController(IMaterialRepository repository) : ControllerBase
    {
        // GET: api/<MaterialController>
        [HttpGet]
        public async Task<IEnumerable<Material>?> GetAll()
        {
            return await repository.GetAllAsync();
        }

        // GET api/<MaterialController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpGet("{id:guid}")]
        public async Task<Material?> Get(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        // POST api/<MaterialController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] MaterialDto item )
        {
            return await repository.CreateAsync(item);
        }

        // PUT api/<MaterialController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpPut("{id:guid}")]
        public async Task<OperationResult> Put(Guid id, [FromBody] MaterialDto item )
        {
            return await repository.UpdateByIdAsync(id, item);
        }

        // DELETE api/<MaterialController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpDelete("{id:guid}")]
        public async Task<OperationResult> Delete(Guid id)
        {
            return await repository.DeleteByIdAsync(id);
        }
    }
}
