using Senlin.Mo.Repository.Abstractions;
using Senlin.Mo.Repository.EFCore.MySQL;
using SenlinWu.Pets.Domain;
using SenlinWu.Pets.Repository.Abstractions;

namespace SenlinWu.Pets.Repository;

public class AddPetRepository(PetDbContext dbContext, IRepositoryHelper helper)
    : Repository<Pet>(dbContext, helper), IAddPetRepository
{
    public Task AddAsync(Pet pet, CancellationToken cancellationToken) 
        => AddEntityAsync(pet, cancellationToken);
}