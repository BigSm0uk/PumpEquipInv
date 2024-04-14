using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core.Abstractions;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain;
[Table("motors")]
public sealed class Motor : IBaseEntity, IMotor
{
    [StringLength(255)]
    public string name { get; set; } = null!;

    [Precision(10, 2)]
    public decimal power { get; set; }

    [Precision(10, 2)]
    public decimal current { get; set; }

    public int nominalspeed { get; set; }

    [Precision(10, 2)]
    public decimal price { get; set; }

    public string? description { get; set; }

    [InverseProperty("motor")]
    public ICollection<Pump> pumps { get; init; } = new List<Pump>();

    public Guid id { get; set; }
}