using InventorySystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.DTO.Notifications
{
    public class NotificationDTO
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public int InventoryId { get; set; }
    }
}
