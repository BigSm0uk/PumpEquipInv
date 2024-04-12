using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Domain.Extensions;
using PumpEquipInv.Core.Interfaces;

namespace PumpEquipInv.DataAccess.Repositories;

public class PumpRepository(PumpDbContext dbContext) : IPumpRepository
{
    public async Task<IEnumerable<Pump>?> GetAllAsync()
    {
        return await dbContext.Pumps
            .ToListAsync();
    }

    public async Task<Pump?> GetByIdAsync(Guid id)
    {
        return await dbContext.Pumps.Include(p => p.motor)
            .Include(p => p.wheelmaterial)
            .Include(p => p.framematerial)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<OperationResult> DeleteByIdAsync(Guid id)
    {
        var pump = await dbContext.Pumps.FirstOrDefaultAsync(x => x.id == id);
        if (pump is null)
        {
            return OperationResult.FailureResult($"Нет насоса с id {id}");
        }

        dbContext.Pumps.Remove(pump);
        await dbContext.SaveChangesAsync();
        return OperationResult.SuccessResult();
    }

    public async Task<Guid> CreateAsync(PumpDto item)
    {
        var id = Guid.NewGuid();
        var pump = await item.ConvertToPump(id);
        await dbContext.Pumps.AddAsync(pump);
        await dbContext.SaveChangesAsync();
        return id;
    }

    public async Task<OperationResult> UpdateByIdAsync(Guid id, PumpDto item)
    {
        var pump = await dbContext.Pumps.FirstOrDefaultAsync(x => x.id == id);
        if (pump is null)
        {
            return OperationResult.FailureResult($"Нет насоса с id {id}");
        }

        var newPump = await item.ConvertToPump(id);
        dbContext.Pumps.Entry(pump).CurrentValues.SetValues(newPump);
        await dbContext.SaveChangesAsync();

        return OperationResult.SuccessResult();
    }
}