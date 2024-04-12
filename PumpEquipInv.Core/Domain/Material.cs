namespace PumpEquipInv.Core.Domain;

public class Material
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Pump> FramePumps { get; set; }
    public ICollection<Pump> WheelPumps { get; set; }
}