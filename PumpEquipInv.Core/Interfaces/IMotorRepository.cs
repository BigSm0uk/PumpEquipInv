using PumpEquipInv.Core.Abstractions;
using PumpEquipInv.Core.Domain;
using PumpEquipInv.Core.Domain.DTOs;

namespace PumpEquipInv.Core.Interfaces;

public interface IMotorRepository : IRepository<Motor>
{
    Task<Guid> CreateAsync(MotorDto item);
    Task<OperationResult> UpdateByIdAsync(Guid id, MotorDto item);
}