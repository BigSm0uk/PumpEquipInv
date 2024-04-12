using PumpEquipInv.Core.Domain.DTOs;

namespace PumpEquipInv.Core.Domain.Extensions;

public static class MaterialExtensions
{
    public static Material ConvertToMaterial(this MaterialDto dto, Guid id)
    {
        return new Material
        {
            id = id,
            description = dto.description, 
            name = dto.name,
        };
    }
}