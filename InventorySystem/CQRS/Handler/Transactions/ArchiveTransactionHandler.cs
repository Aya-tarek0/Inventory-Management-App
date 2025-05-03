using InventorySystem.CQRS.Commands.Transactions;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using MediatR;

namespace InventorySystem.CQRS.Handler.Transactions
{
    public class ArchiveTransactionHandler : IRequestHandler<ArchiveTransactionCommand , string>
    {
        private readonly IGenericRepository<InventoryTransaction> repo;

        public ArchiveTransactionHandler(IGenericRepository<InventoryTransaction> repo)
        {
            this.repo = repo;
        }

        public async Task<string> Handle(ArchiveTransactionCommand request, CancellationToken cancellationToken)
        {
            int currentYear = DateTime.Now.Year;

            var oldTransactions = repo.GetAll()
                .Where(t => t.Date.Year < currentYear)
                .ToList();


            foreach (var t in oldTransactions)
                repo.Remove(t.Id);

            await repo.SaveChangesAsync();
            return $"{oldTransactions.Count} old transactions archived";
        }
    }
}

