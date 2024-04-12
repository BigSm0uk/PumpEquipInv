using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain.DTOs;

public record MotorDto() : IMotor
{
    public required string name { get; set; }
    public decimal power { get; set; }
    public decimal current { get; set; }
    public int nominalspeed { get; set; }
    public decimal price { get; set; }
    public string? description { get; set; }
}