using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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

    public static PumpWithDetailsDto ConvertToPumpWithDetails(this Pump pump)
    {
        pump.framematerial!.pumpwheelmaterials.Clear();
        pump.framematerial!.pumpframematerials.Clear();
        pump.wheelmaterial!.pumpwheelmaterials.Clear();
        pump.wheelmaterial!.pumpframematerials.Clear();
        pump.motor!.pumps.Clear(); //Для избежания циклов данных
       
        
        return new PumpWithDetailsDto
        {
            name = pump.name,
            maxpressure = pump.maxpressure,
            liquidtemperature = pump.liquidtemperature,
            weight = pump.weight,
            price = pump.price,
            motorid = pump.motorid,
            framematerialid = pump.framematerialid,
            wheelmaterialid = pump.wheelmaterialid,
            description = pump.description,
            id = pump.id,
            framematerial = pump.framematerial!,
            motor = pump.motor!,
            wheelmaterial = pump.wheelmaterial!
        };

    }
    public static PumpShortDto ConvertToShortPump(this Pump pump)
    {
        return new PumpShortDto
        {
            name = pump.name,
            maxpressure = pump.maxpressure,
            liquidtemperature = pump.liquidtemperature,
            weight = pump.weight,
            price = pump.price,
            motorid = pump.motorid,
            framematerialid = pump.framematerialid,
            wheelmaterialid = pump.wheelmaterialid,
            description = pump.description,
            id = pump.id
        };

    }
    
 
    private static async Task<byte[]> ConvertIFormFileToByteArray(IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}