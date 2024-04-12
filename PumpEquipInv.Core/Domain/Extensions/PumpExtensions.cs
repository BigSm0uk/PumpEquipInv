using Microsoft.AspNetCore.Http;
using PumpEquipInv.Core.Domain.DTOs;

namespace PumpEquipInv.Core.Domain.Extensions;

public static class PumpExtensions
{
    public static async Task<Pump> ConvertToPump(this PumpDto dto, Guid id)
    {
        var imageData = await ConvertIFormFileToByteArray(dto.file);
        return new Pump
        {
            id = id,
            description = dto.description,
            name = dto.name,
            framematerialid = dto.framematerialid,
            wheelmaterialid = dto.framematerialid,
            image = imageData,
            price = dto.price,
            motorid = dto.motorid,
            imagename = dto.file.FileName,
            liquidtemperature = dto.liquidtemperature,
            weight = dto.weight,
            maxpressure = dto.maxpressure,
        };
    }

    private static async Task<byte[]> ConvertIFormFileToByteArray(IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}