using AutoMapper;
using InventorySystem.CQRS.Query.Inventory;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO.Inventories;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Inventory
{
    public class GetAllInventoryHandler : IRequestHandler<GetAllInventoryQuery, IEnumerable<InventoryDto>>
    {
        public IGenericRepository<Models.Inventory> _genericRepository;
        private readonly IMapper mapper;

        public GetAllInventoryHandler(IGenericRepository<Models.Inventory> genericRepository ,IMapper mapper)
        {
            _genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public Task<IEnumerable<InventoryDto>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Models.Inventory> inventories = _genericRepository.GetAll();
            var inventoryDto = mapper.Map<IEnumerable<InventoryDto>>(inventories);

            return Task.FromResult(inventoryDto);

        }
         

    }
}