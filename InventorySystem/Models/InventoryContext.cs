using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Models
{
    public class InventoryContext:IdentityDbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryTransaction>()
                .HasOne(t => t.FromWarehouse)
                .WithMany(w => w.FromTransactions)
                .HasForeignKey(t => t.FromWarehouseId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<InventoryTransaction>()
                .HasOne(t => t.ToWarehouse)
                .WithMany(w => w.ToTransactions)
                .HasForeignKey(t => t.ToWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Product> Products { set; get; }
        public DbSet<InventoryTransaction> InventoryTransactions { set; get; }
        public DbSet<Inventory> Inventories { set; get; }
        public DbSet<Warehouse> Warehouses { set; get; }
        public DbSet<Notification> Notifications { set; get; }
    }
}
