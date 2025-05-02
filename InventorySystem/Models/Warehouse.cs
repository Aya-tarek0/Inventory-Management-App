using System.ComponentModel.DataAnnotations;
using InventorySystem.DTO;

namespace InventorySystem.Models
{
    public class Warehouse :BaseModel
    {
            public string Name { get; set; }
            public string Location { get; set; }
            public ICollection<Inventory> Inventories { get; set; }
 
            public ICollection<InventoryTransaction> FromTransactions { get; set; } 
            public ICollection<InventoryTransaction> ToTransactions { get; set; }
        }
    }

