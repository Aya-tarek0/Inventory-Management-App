using AutoMapper;
using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.DTO;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Inventory
{
    public class TransferStockHandler : IRequestHandler<TransferStockCommand>
    {
        private readonly IGenericRepository<Models.Inventory> genericRepository;
        private readonly IMapper mapper;

        public TransferStockHandler(IGenericRepository<Models.Inventory> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(TransferStockCommand request, CancellationToken cancellationToken)
        {
            var inventoryFrom = genericRepository.Get(e => e.WarehouseId == request.fromWareHouse&& e.ProductId == request.ProductId).FirstOrDefault();
            var inventoryTo = genericRepository.Get(e => e.WarehouseId == request.ToWareHouse && e.ProductId == request.ProductId).FirstOrDefault();
            if (inventoryFrom == null || inventoryTo == null)
            {
                return Unit.Value;
            }
            Console.WriteLine($"FromWarehouse: {request.fromWareHouse}, ToWarehouse: {request.ToWareHouse}, ProductId: {request.ProductId}");

            inventoryFrom.Quantity -= request.Stock;
            inventoryTo.Quantity += request.Stock;
            genericRepository.Update(inventoryFrom);
            genericRepository.Update(inventoryTo);
           await genericRepository.SaveChangesAsync();

            

            return Unit.Value;

        }
    }
}
