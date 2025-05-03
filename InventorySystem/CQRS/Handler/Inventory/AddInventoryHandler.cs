using AutoMapper;
using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.DTO.Inventories;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using InventorySystem.Repository;
using MediatR;

namespace InventorySystem.CQRS.Handler.Inventory
{
    public class AddInventoryHandler : IRequestHandler<AddInventoryCommand , InventoryDto>
    {
        private readonly IGenericRepository<Models.Inventory> genericRepository;
        private readonly IMapper mapper;

        public AddInventoryHandler(IGenericRepository<Models.Inventory> genericRepository , IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }
        public async Task<InventoryDto> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
        {

            var Inventory = mapper.Map<Models.Inventory>(request.InventoryDto);


            genericRepository.Add(Inventory);
            await genericRepository.SaveChangesAsync();

            var ReturnInventory = mapper.Map<InventoryDto>(Inventory);

            return await Task.FromResult(ReturnInventory);
        }
    }
}
