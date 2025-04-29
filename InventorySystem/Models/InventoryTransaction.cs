using System.ComponentModel.DataAnnotations.Schema;
using InventorySystem.Enum;

namespace InventorySystem.Models
{
    public class InventoryTransaction
    {
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; } 
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

  
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int? FromWarehouseId { get; set; } 
        public Warehouse FromWarehouse { get; set; }

        public int? ToWarehouseId { get; set; } 
        public Warehouse ToWarehouse { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { set; get; }
    }
}
