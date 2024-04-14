using PumpEquipInv.Core.Abstractions;
using PumpEquipInv.Core.Domain;

namespace PumpEquipInv.Core.Interfaces;

public interface IRepository<T> where T : IBaseEntity
{
    public Task<IEnumerable<T>?> GetAllAsync();
    public Task<T?> GetByIdAsync(Guid id);
    public Task<OperationResult> DeleteByIdAsync(Guid id);
}