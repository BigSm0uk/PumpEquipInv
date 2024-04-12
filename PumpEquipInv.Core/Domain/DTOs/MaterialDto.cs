using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain.DTOs;

public record MaterialDto : IMaterial
{
    public required string name { get; set; }
    public string? description { get; set; }
}