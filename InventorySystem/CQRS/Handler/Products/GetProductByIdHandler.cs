using AutoMapper;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO.Products;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using InventorySystem.Repository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InventorySystem.CQRS.Handler.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public IGenericRepository<Models.Product> _genericRepository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IGenericRepository<Models.Product> genericRepository ,IMapper mapper)
        {
            _genericRepository = genericRepository;
            this.mapper = mapper;
        }


        public Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           Models.Product product = _genericRepository.GetByID(request.Id);

            return Task.FromResult(mapper.Map<ProductDto>(product));
        }
    }
}
