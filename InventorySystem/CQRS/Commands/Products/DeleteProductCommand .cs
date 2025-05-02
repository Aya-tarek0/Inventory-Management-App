using MediatR;

namespace InventorySystem.CQRS.Commands.Products
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
