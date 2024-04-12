using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpEquipInv.Core.Abstractions;

namespace PumpEquipInv.Core.Domain;

public class Pump : BaseEntity
{
    [MaxLength(255)] public required string Name { get; init; }

    [Column(TypeName = "decimal(10, 2)")] public required decimal MaxPressure { get; init; }


    [Column(TypeName = "decimal(10, 2)")] public required decimal LiquidTemperature { get; init; }


    [Column(TypeName = "decimal(10, 2)")] public required decimal Weight { get; init; }
    
    [MaxLength(255)] public required string ImageName { get; init; }

    public required byte[] Image { get; init; }

    [Column(TypeName = "decimal(10, 2)")] public required decimal Price { get; init; }
    public required Guid MotorId { get; init; }
    public Motor? Motor { get; init; }
    public required Guid FrameMaterialId { get; init; }
    public Material? FrameMaterial { get; init; }
    public Guid WheelMaterialId { get; init; }
    public Material? WheelMaterial { get; init; }

    public required string Description { get; init; }
}