using InventorySystem.DTO.Transactions;
using MediatR;

namespace InventorySystem.CQRS.Commands.Transactions
{
    public class AddTransactionCommand:IRequest<TransactionDto>
    {
        public TransactionDto transactiondto { set; get; }
    }
}
