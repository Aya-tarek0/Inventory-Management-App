using MediatR;
using InventorySystem.DTO.Transactions;
namespace InventorySystem.CQRS.Commands.Transactions
{
    public class TransferTransactionCommand :IRequest<AddTransferTransactionDTO>
    {
        public AddTransferTransactionDTO AddTransferTransactionDTO { set; get; }
    }
}
