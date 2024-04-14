using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpEquipInv.Core.Abstractions;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain;
[Table("materials")]
public sealed class Material : IBaseEntity, IMaterial
{
    [StringLength(255)]
    public string name { get; set; } = null!;

    public string? description { get; set; }

    [InverseProperty("framematerial")]
    public ICollection<Pump> pumpframematerials { get; set; } = new List<Pump>();

    [InverseProperty("wheelmaterial")]
    public ICollection<Pump> pumpwheelmaterials { get; set; } = new List<Pump>();

    public Guid id { get; set; }
}