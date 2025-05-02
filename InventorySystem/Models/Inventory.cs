using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventorySystem.DTO;

namespace InventorySystem.Models
{
    public class Inventory : BaseModel
    {

            [ForeignKey("Product")]
            public int ProductId { get; set; }
            public Product Product { get; set; }

            public int WarehouseId { get; set; }
            public Warehouse Warehouse { get; set; }

            public int Quantity { get; set; }
            public int LowStockThreshold { get; set; }

        public ICollection<InventoryTransaction> Transactions { get; set; }


    }
}
