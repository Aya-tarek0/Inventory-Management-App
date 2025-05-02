using InventorySystem.DTO.Products;
using MediatR;

namespace InventorySystem.CQRS.Commands.Products
{

    public class AddProductCommand : IRequest<ProductDto>
    {
        public ProductDto product { get; set; }
    }
}
