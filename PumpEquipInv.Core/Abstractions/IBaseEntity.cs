using System.ComponentModel.DataAnnotations;

namespace PumpEquipInv.Core.Abstractions;

public interface IBaseEntity
{
    [Key]
    public Guid id { get; set; }
}