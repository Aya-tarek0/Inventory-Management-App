using System.ComponentModel.DataAnnotations;
using InventorySystem.DTO;

namespace InventorySystem.Models
{
    public class Product :BaseModel
    {
            public string Name { get; set; }
            public string Description { get; set; }

            public double Price { set; get; }

      


    }
}
