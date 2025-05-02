using InventorySystem.DTO.Products;
using MediatR;

namespace InventorySystem.CQRS.Query.Prouct
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
