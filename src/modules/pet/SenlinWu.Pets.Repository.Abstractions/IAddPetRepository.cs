namespace SenlinWu.Pets.Repository.Abstractions;

public interface IAddPetRepository
{
    Task AddAsync(Domain.Pet pet, CancellationToken cancellationToken);
}