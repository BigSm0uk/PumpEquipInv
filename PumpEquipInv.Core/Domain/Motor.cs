using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpEquipInv.Core.Abstractions;

namespace PumpEquipInv.Core.Domain;

public class Motor : BaseEntity
{
    [MaxLength(255)] public required string Name { get; init; }

    [Column(TypeName = "decimal(10, 2)")] public required decimal Power { get; init; }

    [Column(TypeName = "decimal(10, 2)")] public decimal Current { get; init; }

    public required int NominalSpeed { get; init; }

    [Column(TypeName = "decimal(10, 2)")] public required decimal Price { get; init; }

    public required string Description { get; init; }
    
    public IEnumerable<Pump>? Pumps { get; init; }
}