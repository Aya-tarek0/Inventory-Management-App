using InventorySystem.Enum;

namespace InventorySystem.DTO.Reports
{
    public class TransactionHistoryDTO
    {
        public TransactionType? transactionType { set; get; }

        public string ProductName { set; get; }

        public string? Category { set; get; }
        public string UserName { set; get; }


        public DateTime? date { set; get; }
    }
}
