using InventorySystem.DTO;
using MediatR;

namespace InventorySystem.CQRS.Query.Inventory
{
    public class GetInventoryByIdQuery : IRequest<InventoryDto>
    {
        public int Id { get; set; }

    }
}
