using InventorySystem.DTO.Inventories;
using MediatR;

namespace InventorySystem.CQRS.Commands.Inventory
{
    public class AddInventoryCommand : IRequest<InventoryDto>
    {
        public InventoryDto InventoryDto { set; get; }
    }
}
