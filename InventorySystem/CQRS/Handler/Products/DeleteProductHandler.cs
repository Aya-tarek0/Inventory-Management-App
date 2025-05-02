using InventorySystem.CQRS.Commands.Products;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        public IGenericRepository<Models.Product> _genericRepository;

        public DeleteProductHandler(IGenericRepository<Models.Product> genericRepository)
        {
            _genericRepository = genericRepository;

        }

        public Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _genericRepository.Remove(request.Id);
            _genericRepository.SaveChangesAsync();

            return Unit.Task;

        }
    }
}
