using Microsoft.AspNetCore.Http;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain.DTOs;

public record PumpDto : IPumpFullData
{
    public required string name { get; set; }
    public required decimal maxpressure { get; set; }
    public required decimal liquidtemperature { get; set; }
    public required decimal weight { get; set; }
    public required string imagename { get; set; }
    public byte[]? image { get; set; }
    public required decimal price { get; set; }
    public required Guid motorid { get; set; }
    public required Guid framematerialid { get; set; }
    public required Guid wheelmaterialid { get; set; }
    public required string description { get; set; }
    public required IFormFile file { get; set; }

}