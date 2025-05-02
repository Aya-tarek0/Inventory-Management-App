using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventorySystem.DTO;
using InventorySystem.Enum;

namespace InventorySystem.Models
{
    public class InventoryTransaction : BaseModel
    {
        public TransactionType TransactionType { get; set; } 
        public int Quantity { get; set; }
        public DateTime Date { get; set; }


        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }


        [ForeignKey("FromWarehouse")]
        public int? FromWarehouseId { get; set; } 
        public Warehouse FromWarehouse { get; set; }


        [ForeignKey("ToWarehouse")]
        public int? ToWarehouseId { get; set; } 
        public Warehouse ToWarehouse { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { set; get; }
    }
}
