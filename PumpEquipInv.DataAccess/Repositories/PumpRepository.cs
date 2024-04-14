using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Domain.Extensions;
using PumpEquipInv.Core.Interfaces;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.DataAccess.Repositories;

public class PumpRepository(PumpDbContext dbContext) : IPumpRepository
{
    public async Task<IEnumerable<IPump>?> GetAllAsync()
    {
        return await dbContext.pumps.Select(pump => pump.ConvertToShortPump())
            .ToListAsync();
    }

    public async Task<IPump?> GetByIdAsync(Guid id)
    {
        var pump =  await dbContext.pumps.Include(p => p.motor)
            .Include(p => p.wheelmaterial)
            .Include(p => p.framematerial)
            .FirstOrDefaultAsync(x => x.id == id);
        return (pump ?? throw new ArgumentException($"Нет насоса с id {id}")).ConvertToPumpWithDetails();
    }

  
    public async Task<OperationResult> DeleteByIdAsync(Guid id)
    {
        var pump = await dbContext.pumps.FirstOrDefaultAsync(x => x.id == id);
        if (pump is null)
        {
            return OperationResult.FailureResult($"Нет насоса с id {id}");
        }

        dbContext.pumps.Remove(pump);
        await dbContext.SaveChangesAsync();
        return OperationResult.SuccessResult();
    }

    public async Task<Guid> CreateAsync(PumpDto item)
    {
        var id = Guid.NewGuid();
        var pump = await item.ConvertToPump(id);
        await dbContext.pumps.AddAsync(pump);
        await dbContext.SaveChangesAsync();
        return id;
    }

    public async Task<OperationResult> UpdateByIdAsync(Guid id, PumpDto item)
    {
        var pump = await dbContext.pumps.FirstOrDefaultAsync(x => x.id == id);
        if (pump is null)
        {
            return OperationResult.FailureResult($"Нет насоса с id {id}");
        }

        var newPump = await item.ConvertToPump(id);
        dbContext.pumps.Entry(pump).CurrentValues.SetValues(newPump);
        await dbContext.SaveChangesAsync();

        return OperationResult.SuccessResult();
    }

    public async Task<byte[]> GetImageById(Guid id)
    {
        var pump =  await dbContext.pumps.FirstOrDefaultAsync(x => x.id == id);
        return pump?.image ?? throw new ArgumentException($"Нет насоса с id {id}");

    }
}