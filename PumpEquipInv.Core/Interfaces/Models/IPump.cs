using PumpEquipInv.Core.Abstractions;

namespace PumpEquipInv.Core.Interfaces.Models;

public interface IPump : IBaseEntity
{
    public string name { get; set; } 
    
    public decimal maxpressure { get; set; }
    
    public decimal liquidtemperature { get; set; }
    
    public decimal weight { get; set; }
    
    public decimal price { get; set; }

    public Guid motorid { get; set; }

    public Guid framematerialid { get; set; }

    public Guid wheelmaterialid { get; set; }

    public string description { get; set; }
}