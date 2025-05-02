using InventorySystem.DTO;
using MediatR;

namespace InventorySystem.CQRS.Commands.Inventory
{
    public class UpdateInventoryCommand : IRequest<InventoryDto>
    {
        public int Id { get; set; }

        public InventoryDto InventoryDto { set; get; }

    }
}
