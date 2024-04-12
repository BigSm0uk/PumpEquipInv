namespace PumpEquipInv.Core.Interfaces.Models;

public interface IMotor
{
    public string name { get; set; }
    
    public decimal power { get; set; }
    
    public decimal current { get; set; }

    public int nominalspeed { get; set; }

    public decimal price { get; set; }

    public string? description { get; set; }
}