using MediatR;

namespace InventorySystem.CQRS.Commands.Inventory
{
    public class DeleteInventoryCommand : IRequest

    {
        public int Id { get; set; }


    }
}

