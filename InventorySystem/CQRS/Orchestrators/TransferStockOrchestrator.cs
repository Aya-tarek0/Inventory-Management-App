using AutoMapper;
using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.CQRS.Commands.Transactions;
using InventorySystem.DTO.Transactions;
using InventorySystem.Enum;
using MediatR;

namespace InventorySystem.CQRS.Orchestrators
{
    public class TransferStockOrchestrator : IRequest<AddTransferTransactionDTO>
    {
        public TransactionType TransactionType { get; set; } = TransactionType.Transfer;

        public int FromId { set; get; }

        public int ToId { set; get; }
        public int ProductId { set; get; }
        public int InventoryId { set; get; }
        public int Stock { set; get; }

        public DateTime Date { get; set; }



        public string UserId { get; set; }
    }
    public class TransferStockOrchestratorHandler : IRequestHandler<TransferStockOrchestrator, AddTransferTransactionDTO>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TransferStockOrchestratorHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<AddTransferTransactionDTO> Handle(TransferStockOrchestrator request, CancellationToken cancellationToken)
        {
            var updateInventory = await _mediator.Send(new TransferStockCommand
            {

                Stock = request.Stock,
                fromWareHouse =request.FromId,
                ToWareHouse = request.ToId,
                ProductId = request.ProductId,
                //TransferTransactionDTO = transactionDto,
            });

            if (updateInventory == null)
                throw new Exception("Inventory not found");

            var transactionDto = new AddTransferTransactionDTO
            {
                InventoryId = request.InventoryId,
                Stock = request.Stock,
                TransactionType = request.TransactionType,
                UserId = request.UserId,
                Date = DateTime.Now,
                FromId = request.FromId,
                ToId = request.ToId

            };

            var result = await _mediator.Send(new TransferTransactionCommand
            {
               AddTransferTransactionDTO = transactionDto
            });

            return result;

        }


    } }



