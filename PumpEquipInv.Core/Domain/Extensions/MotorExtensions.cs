using PumpEquipInv.Core.Domain.DTOs;

namespace PumpEquipInv.Core.Domain.Extensions;

public static class MotorExtensions
{
    public static Motor ConvertToMotor(this MotorDto dto, Guid id)
    {
        return new Motor
        {
            id = id,
            description = dto.description, 
            name = dto.name,
            current = dto.current,
            price = dto.price,
            nominalspeed = dto.nominalspeed,
            power = dto.power
        };
    }
}