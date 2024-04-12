using PumpEquipInv.Core.Abstractions;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;

namespace PumpEquipInv.Core.Interfaces;

public interface IPumpRepository : IRepository<Pump>
{
    Task<Guid> CreateAsync(PumpDto item);
    Task<OperationResult> UpdateByIdAsync(Guid id, PumpDto item);
}
   