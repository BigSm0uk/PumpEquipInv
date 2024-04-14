using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Domain.Extensions;
using PumpEquipInv.Core.Interfaces;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.DataAccess.Repositories;

public class MaterialRepository(PumpDbContext dbContext) : IMaterialRepository
{
    public async Task<IEnumerable<Material>?> GetAllAsync()
    {
        return await dbContext.materials
            .ToListAsync();
    }

    public async Task<Material?> GetByIdAsync(Guid id)
    {
        return await dbContext.materials.Include(m => m.pumpframematerials).Include(m => m.pumpwheelmaterials)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<OperationResult> DeleteByIdAsync(Guid id)
    {
        var material = await dbContext.materials.FirstOrDefaultAsync(x => x.id == id);
        if (material is null)
        {
            return OperationResult.FailureResult($"Нет материала с id {id}");
        }

        dbContext.materials.Remove(material);
        await dbContext.SaveChangesAsync();
        return OperationResult.SuccessResult();
    }

    public async Task<Guid> CreateAsync(MaterialDto item)
    {
        var id = Guid.NewGuid();
        var material = item.ConvertToMaterial(id);
        await dbContext.materials.AddAsync(material);
        await dbContext.SaveChangesAsync();
        return id;
    }

    public async Task<OperationResult> UpdateByIdAsync(Guid id, MaterialDto item)
    {
        var material = await dbContext.materials.FirstOrDefaultAsync(x => x.id == id);
        if (material is null)
        {
            return OperationResult.FailureResult($"Нет материала с id {id}");
        }

        var newMaterial = item.ConvertToMaterial(id);
        dbContext.materials.Entry(material).CurrentValues.SetValues(newMaterial);
        await dbContext.SaveChangesAsync();

        return OperationResult.SuccessResult();
    }
}