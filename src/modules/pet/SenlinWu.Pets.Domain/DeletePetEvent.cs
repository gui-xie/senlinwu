using Senlin.Mo.Domain;

namespace SenlinWu.Pets.Domain;

public class DeletePetEvent(string petName) : IDomainEvent
{
    public string PetName { get; } = petName;
}