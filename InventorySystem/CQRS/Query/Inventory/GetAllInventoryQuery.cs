using InventorySystem.DTO;
using MediatR;

namespace InventorySystem.CQRS.Query.Inventory
{
    public class GetAllInventoryQuery : IRequest<IEnumerable<InventoryDto>>
    {
    }
}
