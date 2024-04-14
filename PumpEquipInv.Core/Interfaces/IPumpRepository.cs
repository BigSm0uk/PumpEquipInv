
using PumpEquipInv.Core.Domain.DTOs;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Interfaces;

public interface IPumpRepository : IRepository<IPump>
{
    Task<Guid> CreateAsync(PumpDto item);
    Task<OperationResult> UpdateByIdAsync(Guid id, PumpDto item);
    Task<byte[]> GetImageById(Guid id);
}
   