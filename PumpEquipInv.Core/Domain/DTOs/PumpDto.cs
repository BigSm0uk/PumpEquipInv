using Microsoft.AspNetCore.Http;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain.DTOs;

public record PumpDto : IPump
{
    public required string name { get; set; }
    public decimal maxpressure { get; set; }
    public decimal liquidtemperature { get; set; }
    public decimal weight { get; set; }
    public string? imagename { get; set; }
    public byte[]? image { get; set; }
    public decimal price { get; set; }
    public Guid? motorid { get; set; }
    public Guid? framematerialid { get; set; }
    public Guid? wheelmaterialid { get; set; }
    public string? description { get; set; }
    public required IFormFile file { get; set; } 
}