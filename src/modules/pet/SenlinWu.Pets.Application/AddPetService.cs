using SenlinWu.Pets.Repository.Abstractions;

namespace SenlinWu.Pets.Application;

public class AddPetService(IAddPetRepository repository) : ICommandService<AddPetDto, string>
{
    public async Task<IResult<string>> ExecuteAsync(AddPetDto request, CancellationToken cancellationToken)
    {
        var pet = Domain.Pet.Create(request.Name);
        await repository.AddAsync(pet, cancellationToken);
        return Result.Success(pet.Id.ToString());
    }
}