using System.ComponentModel.DataAnnotations;
using PumpEquipInv.Core.Abstractions;

namespace PumpEquipInv.Core.Domain;

public class Material : BaseEntity
{
    [MaxLength(255)] public required string Name { get; init; }

    public required string Description { get; init; }
    
    public IEnumerable<Pump>? Pumps { get; init; }
}