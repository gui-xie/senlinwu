using SenlinWu.Pets.Domain;

namespace SenlinWu.Pets.Application;

public class DeletePetEventHandler : IPostEventHandler<DeletePetEvent>
{
    public Task ExecuteAsync(DeletePetEvent e, CancellationToken cancellationToken)
    {
        // Send email to notify the pet owner
        Console.WriteLine($"Email sent to {e.PetName} Owner");
        return Task.CompletedTask;
    }
}