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
        return await dbContext.Materials
            .ToListAsync();
    }

    public async Task<Material?> GetByIdAsync(Guid id)
    {
        return await dbContext.Materials.Include(m => m.pumpframematerials).Include(m => m.pumpwheelmaterials)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<OperationResult> DeleteByIdAsync(Guid id)
    {
        var material = await dbContext.Materials.FirstOrDefaultAsync(x => x.id == id);
        if (material is null)
        {
            return OperationResult.FailureResult($"Нет материала с id {id}");
        }

        dbContext.Materials.Remove(material);
        await dbContext.SaveChangesAsync();
        return OperationResult.SuccessResult();
    }

    public async Task<Guid> CreateAsync(MaterialDto item)
    {
        var id = Guid.NewGuid();
        var material = item.ConvertToMaterial(id);
        await dbContext.Materials.AddAsync(material);
        await dbContext.SaveChangesAsync();
        return id;
    }

    public async Task<OperationResult> UpdateByIdAsync(Guid id, MaterialDto item)
    {
        var material = await dbContext.Materials.FirstOrDefaultAsync(x => x.id == id);
        if (material is null)
        {
            return OperationResult.FailureResult($"Нет материала с id {id}");
        }

        var newMaterial = item.ConvertToMaterial(id);
        dbContext.Materials.Entry(material).CurrentValues.SetValues(newMaterial);
        await dbContext.SaveChangesAsync();

        return OperationResult.SuccessResult();
    }
}