using InventorySystem.Models;

namespace InventorySystem.DTO
{
    public class InventoryDto
    {
        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int Quantity { get; set; }
        public int LowStockThreshold { get; set; }
    }
}
