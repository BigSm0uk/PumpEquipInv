using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Domain.Extensions;
using PumpEquipInv.Core.Interfaces;

namespace PumpEquipInv.DataAccess.Repositories;

public class MotorRepository(PumpDbContext dbContext) : IMotorRepository
{
    public async Task<IEnumerable<Motor>?> GetAllAsync()
    {
        return await dbContext.Motors
            .ToListAsync();
    }

    public async Task<Motor?> GetByIdAsync(Guid id)
    {
        return await dbContext.Motors.Include(m=>m.pumps).FirstOrDefaultAsync(x=> x.id == id);
    }

    public async Task<OperationResult> DeleteByIdAsync(Guid id)
    {
        var motor = await dbContext.Motors.FirstOrDefaultAsync(x=> x.id == id);
        if (motor is null)
        {
            return OperationResult.FailureResult($"Нет мотора с id {id}");
        }
        dbContext.Motors.Remove(motor);
        await dbContext.SaveChangesAsync();
        return OperationResult.SuccessResult();
    }

    public async Task<Guid> CreateAsync(MotorDto item)
    {
        var id = Guid.NewGuid();
        var motor = item.ConvertToMotor(id);
        await dbContext.Motors.AddAsync(motor);
        await dbContext.SaveChangesAsync();
        return id;
    }

    public async Task<OperationResult> UpdateByIdAsync(Guid id, MotorDto item)
    {
        var motor = await dbContext.Motors.FirstOrDefaultAsync(x=> x.id == id);
        if (motor is null)
        {
            return OperationResult.FailureResult($"Нет мотора с id {id}");
        }

        var newMotor = item.ConvertToMotor(id);
        dbContext.Motors.Entry(motor).CurrentValues.SetValues(newMotor);
        await dbContext.SaveChangesAsync();
        
        return OperationResult.SuccessResult();
    }
}