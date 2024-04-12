namespace PumpEquipInv.Core.Domain;

public class Motor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Power { get; set; }
    public decimal Current { get; set; }
    public int NominalSpeed { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public ICollection<Pump> Pumps { get; set; }
}