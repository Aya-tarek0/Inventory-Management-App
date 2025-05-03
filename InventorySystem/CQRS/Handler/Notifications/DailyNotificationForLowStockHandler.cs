using AutoMapper;
using InventorySystem.CQRS.Commands.Notifications;
using InventorySystem.CQRS.Query.Reports;
using InventorySystem.Enum;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using MediatR;

namespace InventorySystem.CQRS.Handler.Notifications
{
    public class DailyNotificationForLowStockHandler : IRequestHandler<DailyNotificationForLowStockCommand, string>
    {
        public IGenericRepository<Notification> _genericRepository;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public DailyNotificationForLowStockHandler(IGenericRepository<Notification> genericRepository, IMapper mapper , IMediator mediator)
        {
            _genericRepository = genericRepository;
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public async Task<string> Handle(DailyNotificationForLowStockCommand request, CancellationToken cancellationToken)
        {
            var query = new GetAllUnderLowStockQuery { };
            

            var result = await mediator.Send(query);

            foreach(var product in result)
            {
                var notification = new Notification()
                {
                    InventoryId = product.InventoryId,
                    Message = request.message,
                    CreatedAt = request.dateTime
                };
                _genericRepository.Add(notification);

            }
           await _genericRepository.SaveChangesAsync();

            return ($"The List Of Products That Under Low Stock {query}");
        }
    }
}
