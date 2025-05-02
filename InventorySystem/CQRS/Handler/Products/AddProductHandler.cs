using AutoMapper;
using Azure.Core;
using InventorySystem.CQRS.Commands.Products;
using InventorySystem.DTO.Products;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using InventorySystem.Repository;
using MediatR;

namespace InventorySystem.CQRS.Handler.Products
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductDto>
    {

        public IGenericRepository<Models.Product> _genericRepository;
        private readonly IMapper mapper;

        public AddProductHandler(IGenericRepository<Models.Product> genericRepository ,IMapper mapper)
        {
            _genericRepository = genericRepository;
            this.mapper = mapper;
        }


        public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Models.Product>(request.product);

            _genericRepository.Add(product);
            await _genericRepository.SaveChangesAsync();

            var newProduct = mapper.Map<ProductDto>(product);

            return await Task.FromResult(newProduct);

        }
    }

}

