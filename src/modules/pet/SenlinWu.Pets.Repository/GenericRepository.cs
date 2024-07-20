using Microsoft.EntityFrameworkCore;
using Senlin.Mo.Domain;
using Senlin.Mo.Repository.Abstractions;
using Senlin.Mo.Repository.EFCore.MySQL;
using SenlinWu.Pets.Repository.Abstractions;

namespace SenlinWu.Pets.Repository;

public class GenericRepository<T>(PetDbContext dbContext, IRepositoryHelper helper)
    : Repository<T>(dbContext, helper), IGenericRepository<T> where T : Entity
{
    public Task AddAsync(T entity, CancellationToken cancellationToken) 
        => AddEntityAsync(entity, cancellationToken);

    public Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        UpdateEntity(entity, cancellationToken);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        DeleteEntity(entity, cancellationToken);
        return Task.CompletedTask;
    }

    public Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        return GetAsync(Convert.ToInt64(id), cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = dbContext.Set<T>();
        var result = await query.ToArrayAsync(cancellationToken: cancellationToken);
        return result;
    }
}