using InventorySystem.DTO.Products;
using MediatR;

namespace InventorySystem.CQRS.Query.Prouct
{

    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }

}
