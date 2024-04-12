using System.ComponentModel.DataAnnotations;

namespace PumpEquipInv.Core.Abstractions;

public abstract class BaseEntity
{
    [Key]
    public Guid id { get; set; }
}