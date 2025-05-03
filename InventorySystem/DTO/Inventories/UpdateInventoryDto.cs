namespace InventorySystem.DTO.Inventories
{
    public class UpdateInventoryDto
    {

        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int Quantity { get; set; }
        public int LowStockThreshold { get; set; }
    }
}
