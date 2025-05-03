using AutoMapper;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO.Products;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Product
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductInventoriesDTO>>
    {
        public IGenericRepository<Models.Product> _genericRepository;
        public IMapper Mapper { get; }
        public GetAllProductsHandler(IGenericRepository<Models.Product> genericRepository ,IMapper mapper)
        {
            _genericRepository = genericRepository;
            Mapper = mapper;
        }

       

        public Task<IEnumerable<ProductInventoriesDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            IEnumerable<Models.Product> products = _genericRepository.GetAll().Where(e => e.inventories != null && e.inventories.Any())
;

            IEnumerable<ProductInventoriesDTO> productDto = Mapper.Map<IEnumerable<ProductInventoriesDTO>>(products);

            return Task.FromResult(productDto);

        }

    }
}
