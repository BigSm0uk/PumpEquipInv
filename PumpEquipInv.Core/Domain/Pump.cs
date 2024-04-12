namespace PumpEquipInv.Core.Domain;

public class Pump
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal MaxPressure { get; set; }
    public decimal LiquidTemperature { get; set; }
    public decimal Weight { get; set; }
    public string ImagePath { get; set; }
    public decimal Price { get; set; }

    public int MotorId { get; set; }
    public Motor Motor { get; set; }

    public int FrameMaterialId { get; set; }
    public Material FrameMaterial { get; set; }

    public int WheelMaterialId { get; set; }
    public Material WheelMaterial { get; set; }

    public string Description { get; set; }
}
