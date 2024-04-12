using PumpEquipInv.Core.Domain.DTOs;

namespace PumpEquipInv.Core.Domain.Extensions;

public static class PumpExtensions
{
    public static Pump ConvertToPump(this PumpDto dto, Guid id)
    {
        return new Pump
        {
            id = id,
            description = dto.description,
            name = dto.name,
            framematerialid = dto.framematerialid,
            wheelmaterialid = dto.framematerialid,
            image = dto.image,
            price = dto.price,
            motorid = dto.motorid,
            imagename = dto.imagename,
            liquidtemperature = dto.liquidtemperature,
            weight = dto.weight,
            maxpressure = dto.maxpressure,
        };
    }
}