using AutoMapper;
using InventorySystem.CQRS.Query.Inventory;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Inventory
{
    public class GetInventoryByIdHandler : IRequestHandler<GetInventoryByIdQuery, InventoryDto>
    {
        public IGenericRepository<Models.Inventory> _genericRepository;
        private readonly IMapper mapper;

        public GetInventoryByIdHandler(IGenericRepository<Models.Inventory> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            Models.Inventory inventory = _genericRepository.GetByID(request.Id);



            return Task.FromResult(mapper.Map<InventoryDto>(inventory));
        }
    }
}

