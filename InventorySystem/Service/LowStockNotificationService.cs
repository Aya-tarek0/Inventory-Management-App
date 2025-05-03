using InventorySystem.CQRS.Commands.Notifications;
using MediatR;

namespace InventorySystem.Service
{
    public class LowStockNotificationService
    {
        private readonly IMediator _mediator;

        public LowStockNotificationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ExecuteFunction()
        {
            var command = new DailyNotificationForLowStockCommand
            {
                message = "Low stock alert",
                dateTime = DateTime.Now
            };

            await _mediator.Send(command);
        }
    }

}
