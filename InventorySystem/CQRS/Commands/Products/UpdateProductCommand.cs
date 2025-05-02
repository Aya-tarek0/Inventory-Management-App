using InventorySystem.DTO.Products;
using MediatR;

namespace InventorySystem.CQRS.Commands.Products
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
    }
}
