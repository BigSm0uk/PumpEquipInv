namespace PumpEquipInv.Core.Interfaces.Models;

public interface IPumpFullData : IShortPump
{
    public string imagename { get; set; } 
    
    public byte[]? image { get; set; }

}