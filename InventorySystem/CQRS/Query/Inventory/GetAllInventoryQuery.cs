using InventorySystem.DTO.Inventories;
using MediatR;

namespace InventorySystem.CQRS.Query.Inventory
{
    public class GetAllInventoryQuery : IRequest<IEnumerable<InventoryDto>>
    {
    }
}
