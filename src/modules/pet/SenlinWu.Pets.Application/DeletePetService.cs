using SenlinWu.Pets.Domain;
using SenlinWu.Pets.Repository.Abstractions;

namespace SenlinWu.Pets.Application;

public class DeletePetService(IGenericRepository<Pet> repository, IL l) : ICommandService<DeletePetDto>
{
    public async Task<IResult> ExecuteAsync(DeletePetDto request, CancellationToken cancellationToken)
    {
            var pet = await repository.GetByIdAsync(request.Id, cancellationToken);
            if (pet == null) return Result.Fail(l[L.ERR_PetNotFound]);
            pet.Delete();
            await repository.DeleteAsync(pet, cancellationToken);
            return Result.Success();
    }
}