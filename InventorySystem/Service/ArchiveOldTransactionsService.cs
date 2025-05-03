using InventorySystem.CQRS.Commands.Transactions;
using MediatR;

namespace InventorySystem.Service
{
    public class ArchiveOldTransactionsService
    {


        private readonly IMediator mediator;

        public ArchiveOldTransactionsService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task ExecuteFun()
        {
            var command = new ArchiveTransactionCommand();
            await mediator.Send(command);
        }
    }

}
