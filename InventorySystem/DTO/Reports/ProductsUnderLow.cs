namespace InventorySystem.DTO.Reports
{
    public class ProductsUnderLow
    {
        public string ProductName { set; get; }
        public string WareHouseName{set; get;}

        public string Category { set; get; }

        public int InventoryId { get; set; }

    }
}
