namespace PumpEquipInv.Core.Interfaces.Models;

public interface IPump
{
    public string name { get; set; } 
    
    public decimal maxpressure { get; set; }
    
    public decimal liquidtemperature { get; set; }
    
    public decimal weight { get; set; }
    
    public string imagename { get; set; } 
    
    public byte[]? image { get; set; }
    
    public decimal price { get; set; }

    public Guid? motorid { get; set; }

    public Guid? framematerialid { get; set; }

    public Guid? wheelmaterialid { get; set; }

    public string? description { get; set; }
}