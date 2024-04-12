using System.ComponentModel.DataAnnotations;

namespace PumpEquipInv.Core.Abstractions;

public abstract class BaseEntity
{
    [Key]
    private Guid Id { get; set; }
}