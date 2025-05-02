using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventorySystem.DTO;

namespace InventorySystem.Models
{
    public class Notification : BaseModel
    {
            public string Message { get; set; }
            public DateTime CreatedAt { get; set; }


        [ForeignKey("Inventory")]
            public int InventoryId { get; set; }
            public Inventory Inventory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
