using AutoMapper;
using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.DTO;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Inventory
{
    public class RemoveStockHandler : IRequestHandler<RemoveStockCommand, UpdateInventoryDto>

    {
        private readonly IGenericRepository<Models.Inventory> genericRepository;
        private readonly IMapper mapper;

        public RemoveStockHandler(IGenericRepository<Models.Inventory> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateInventoryDto> Handle(RemoveStockCommand request, CancellationToken cancellationToken)
        {
            var inventory = genericRepository
                .Get(e => e.Id == request.InventoryId)
                .FirstOrDefault();
            if (inventory == null)
                return null;

            inventory.Quantity -= request.quantity;
            genericRepository.Update(inventory);
            await genericRepository.SaveChangesAsync();

            var inventoryDto = mapper.Map<UpdateInventoryDto>(inventory);
            return inventoryDto;

        }

    }
}
