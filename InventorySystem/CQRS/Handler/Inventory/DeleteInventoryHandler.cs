using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.CQRS.Commands.Products;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Inventory
{
    public class DeleteInventoryHandler : IRequestHandler<DeleteInventoryCommand>
    {
        public IGenericRepository<Models.Inventory> _genericRepository;

        public DeleteInventoryHandler(IGenericRepository<Models.Inventory> genericRepository)
        {
            _genericRepository = genericRepository;

        }


     public Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            _genericRepository.Remove(request.Id);
            _genericRepository.SaveChangesAsync();

            return Unit.Task;  

        }
    }
}
