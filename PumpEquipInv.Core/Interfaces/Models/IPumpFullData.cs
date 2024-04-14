namespace PumpEquipInv.Core.Interfaces.Models;

public interface IPumpFullData : IPump
{
    public string imagename { get; set; } 
    
    public byte[]? image { get; set; }

}