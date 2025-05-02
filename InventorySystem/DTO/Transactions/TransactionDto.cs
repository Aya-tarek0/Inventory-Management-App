using InventorySystem.Enum;
using InventorySystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.DTO.Transactions
{
    public class TransactionDto
    {
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public int InventoryId { get; set; }

        public string UserId { get; set; }

    }
}
