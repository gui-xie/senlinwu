using SenlinWu.Pets.Domain;

namespace SenlinWu.Pets.Application;

public class DeletePetBeforeTransactionEventHandler : IEventHandler<DeletePetEvent>
{
    public Task ExecuteAsync(DeletePetEvent e, CancellationToken cancellationToken)
    {
        // if EventHandler throw exception, the transaction will not be committed
        throw new NotImplementedException();
        
        return Task.CompletedTask;
    }
}