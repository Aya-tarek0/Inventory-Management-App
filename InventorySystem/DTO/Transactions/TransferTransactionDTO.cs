namespace InventorySystem.DTO.Transactions
{
    public class TransferTransactionDTO
    {
        public int productId { set; get; }
        public int FromId { set; get; }

        public int ToId { set; get; }

        public int Stock { set; get; }
    }
}
