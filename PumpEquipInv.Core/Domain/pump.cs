using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core.Abstractions;
using PumpEquipInv.Core.Interfaces.Models;

namespace PumpEquipInv.Core.Domain;
[Table("pumps")]
public sealed class Pump : IPumpFullData, IPumpWithDetails
{
    [StringLength(255)]
    public string name { get; set; } = null!;

    [Precision(10, 2)]
    public decimal maxpressure { get; set; }

    [Precision(10, 2)]
    public decimal liquidtemperature { get; set; }

    [Precision(10, 2)]
    public decimal weight { get; set; }

    [StringLength(255)]
    public string imagename { get; set; } = null!;

    public byte[]? image { get; set; }

    [Precision(10, 2)]
    public decimal price { get; set; }

    public Guid motorid { get; set; }

    public Guid framematerialid { get; set; }

    public Guid wheelmaterialid { get; set; }

    public required string description { get; set; }

    [ForeignKey("framematerialid")]
    [InverseProperty("pumpframematerials")]
    public Material? framematerial { get; set; }

    [ForeignKey("motorid")]
    [InverseProperty("pumps")]
    public Motor? motor { get; set; }

    [ForeignKey("wheelmaterialid")]
    [InverseProperty("pumpwheelmaterials")]
    public Material? wheelmaterial { get; set; }

    public Guid id { get; set; }
}