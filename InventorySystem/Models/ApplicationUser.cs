using Microsoft.AspNetCore.Identity;

namespace InventorySystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ICollection<InventoryTransaction> Transactions { get; set; }

    }
}
