using Senlin.Mo.Domain;

namespace SenlinWu.Pets.Domain;

public class Pet: Entity
{
    public string Name { get; private set; } = string.Empty;

    public static Pet Create(string name)
    {
        return new Pet
        {
            Name = name
        };
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void Delete()
    {
        AddDomainEvent(new DeletePetEvent(Name));
    }
}