using MediatR;

namespace InventorySystem.CQRS.Commands.Transactions
{
    public class ArchiveTransactionCommand : IRequest<string>
    {
    }
}
