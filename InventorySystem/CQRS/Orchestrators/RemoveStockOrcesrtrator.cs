using AutoMapper;
using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.CQRS.Commands.Transactions;
using InventorySystem.DTO.Transactions;
using InventorySystem.Enum;
using MediatR;

namespace InventorySystem.CQRS.Orchestrators
{
    public class RemoveStockOrcesrtrator : IRequest<TransactionDto>
    {
        public int inventoryid { get; set; }

        public int Quantity { get; set; }
        public TransactionType TransactionType { get; set; } = TransactionType.Remove;
        public string DoneBy { get; set; }
    }

    public class RemoveStockOrchestratorHandler : IRequestHandler<RemoveStockOrcesrtrator, TransactionDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RemoveStockOrchestratorHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TransactionDto> Handle(RemoveStockOrcesrtrator request, CancellationToken cancellationToken)
        {
            var updateInventory = await _mediator.Send(new RemoveStockCommand
            {
                InventoryId = request.inventoryid,
                quantity = request.Quantity
            });

            if (updateInventory == null)
                throw new Exception("Inventory not found");

            var transactionDto = new TransactionDto
            {
                InventoryId = request.inventoryid,

                Quantity = request.Quantity,
                TransactionType = request.TransactionType,
                UserId = request.DoneBy,
                Date = DateTime.Now
            };

            var result = await _mediator.Send(new AddTransactionCommand
            {
                transactiondto = transactionDto
            });

            return result;
        }
    }
}


