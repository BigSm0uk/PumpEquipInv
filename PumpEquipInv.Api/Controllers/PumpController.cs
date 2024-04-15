using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Interfaces;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpController(IPumpRepository repository) : ControllerBase
    {
        // GET: api/<PumpController>
        [HttpGet]
        public async Task<IEnumerable<IPump>?> GetAll()
        {
            return await repository.GetAllAsync();
        }

        // GET api/<PumpController>/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpGet("{id:guid}")]
        public async Task<IPump?> Get(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }
        // GET api/<PumpController>/img/6ecd8c99-4036-403d-bf84-cf8400f67837
        [HttpGet("/api/[controller]/img/{id:guid}")]
        public async Task<IActionResult> GetImg(Guid id)
        {
            return File(await repository.GetImageById(id), "image/jpeg");
        }

        // POST api/<PumpController>
        [HttpPost]
        public async Task<Guid> Post([FromForm] PumpDto item)
        {
            var name = item.file.ContentType;
            if(!name.Equals("image/jpeg")) throw new ArgumentException("Неправильное расширение файла");
            return await repository.CreateAsync(item);
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
