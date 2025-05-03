using InventorySystem.DTO.Notifications;
using MediatR;

namespace InventorySystem.CQRS.Commands.Notifications
{
    public class DailyNotificationForLowStockCommand : IRequest<string>
    {
        public string message { set; get; }
        public DateTime  dateTime { set; get; }


        public int inventoryid { set; get; }
    }
}
