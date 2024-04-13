using System.Drawing;
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
        public async Task<Guid> Post([FromForm] PumpDto item)
        {
            var name = item.file.ContentType;
            if(!name.Equals("image/jpeg")) throw new ArgumentException("Неправильное расширение файла");
            return await repository.CreateAsync(item);
        }
        [HttpPost("test")]
        public async Task<IActionResult> PostTest(IFormFile item)
        {
            using var memoryStream = new MemoryStream();
            await item.CopyToAsync(memoryStream);
            var res =  memoryStream.ToArray();
            return File(res, "image/png");
        }

        // PUT api/<PumpController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpPut("{id:guid}")]
        public async Task<OperationResult> Put(Guid id, [FromForm] PumpDto item )
        {
            var name = item.file.ContentType;
            if(!name.Equals("image/jpeg")) throw new ArgumentException("Неправильное расширение файла");
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
