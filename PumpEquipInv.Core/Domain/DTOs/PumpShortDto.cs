using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain.DTOs;

public class PumpShortDto : IPump
{
    public required string name { get; set; }
    public required decimal maxpressure { get; set; }
    public required decimal liquidtemperature { get; set; }
    public required decimal weight { get; set; }
    public required decimal price { get; set; }
    public required Guid motorid { get; set; }
    public required Guid framematerialid { get; set; }
    public required Guid wheelmaterialid { get; set; }
    public required string description { get; set; }
    public required Guid id { get; set; }
}