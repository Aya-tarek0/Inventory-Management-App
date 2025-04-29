using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
            public int Quantity { get; set; }
            public double Price { get; set; }
            public int LowStockThreshold { get; set; }

           
            public ICollection<Transaction> InventoryTransactions { get; set; } 
     

    }
}
