using Senlin.Mo.Domain;

namespace SenlinWu.Pets.Repository.Abstractions;

public interface IGenericRepository<T> where T : Entity
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken);
    
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
}