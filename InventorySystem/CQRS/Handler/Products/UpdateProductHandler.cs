using AutoMapper;
using InventorySystem.CQRS.Commands.Products;
using InventorySystem.DTO.Products;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using InventorySystem.Repository;
using MediatR;

namespace InventorySystem.CQRS.Handler.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        public IGenericRepository<Models.Product> _genericRepository;
        public IMapper Mapper { get; }

        public UpdateProductHandler(IGenericRepository<Models.Product> genericRepository , IMapper mapper)
        {
            _genericRepository = genericRepository;
            Mapper = mapper;
        }


        public Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Models.Product product = _genericRepository.GetByID(request.Id);
         

            _genericRepository.Update(product);
           _genericRepository.SaveChangesAsync();

          var productdto=  Mapper.Map<ProductDto>(product);

            return Task.FromResult(productdto);
        }
    }
}
