using AutoMapper;
using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO.Inventories;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using MediatR;

namespace InventorySystem.CQRS.Handler.Inventory
{
    public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand, InventoryDto>

    {
        public IGenericRepository<Models.Inventory> _genericRepository;
        private readonly IMapper mapper;

        public UpdateInventoryHandler(IGenericRepository<Models.Inventory> genericRepository ,IMapper mapper)
        {
            _genericRepository = genericRepository;
            this.mapper = mapper;
        }


public Task<InventoryDto> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            Models.Inventory inventory = _genericRepository.GetByID(request.Id);
          
            _genericRepository.Update(inventory);

            var inventorydto = mapper.Map<InventoryDto>(inventory);


            return Task.FromResult(inventorydto);
        }
    }
}
