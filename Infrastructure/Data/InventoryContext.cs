using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
namespace Infrastructure.Data
{
    internal class InventoryContext(DbContextOptions<InventoryContext> options):DbContext(options)
    {
        public DbSet<Product> products { set; get; }
    }
}
