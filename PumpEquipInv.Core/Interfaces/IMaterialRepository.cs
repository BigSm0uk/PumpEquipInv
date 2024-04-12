using PumpEquipInv.Core.Abstractions;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;

namespace PumpEquipInv.Core.Interfaces;

public interface IMaterialRepository : IRepository<Material>
{
    Task<Guid> CreateAsync(MaterialDto item);
    Task<OperationResult> UpdateByIdAsync(Guid id, MaterialDto item);
}