using InventorySystem.DTO.Reports;
using InventorySystem.Enum;
using MediatR;

namespace InventorySystem.CQRS.Query.Reports
{
    public class GetTransactionsForProductQuery : IRequest<IEnumerable<TransactionHistoryDTO>>
    {
        public Filter filter { set; get; }

        public int ProductId { set; get; }
        public string? Category { set; get; }

        public DateTime? dateTime { set; get; }

        public TransactionType? TransactionType { set; get; }
    }
}
