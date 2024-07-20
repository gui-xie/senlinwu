using SenlinWu.Pets.Domain;
using SenlinWu.Pets.Repository.Abstractions;

namespace SenlinWu.Pets.Application;

public class UpdatePetService(IGenericRepository<Pet> repository, IL l)
    : ICommandService<UpdatePetDto>
{
    public async Task<IResult> ExecuteAsync(UpdatePetDto request, CancellationToken cancellationToken)
    {
        var pet = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (pet == null) return Result.Fail(l[L.ERR_PetNotFound]);
        pet.UpdateName(request.Name);
        await repository.UpdateAsync(pet, cancellationToken);
        return Result.Success();
    }
}