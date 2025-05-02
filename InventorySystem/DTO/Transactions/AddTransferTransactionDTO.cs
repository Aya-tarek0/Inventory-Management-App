using InventorySystem.Enum;

namespace InventorySystem.DTO.Transactions
{
    public class AddTransferTransactionDTO
    {
        public TransactionType TransactionType { get; set; }

        public int FromId { set; get; }

        public int ToId { set; get; }

        public int Stock { set; get; }

        public DateTime Date { get; set; }

        public int InventoryId { get; set; }



        public string UserId { get; set; }
    }
}
