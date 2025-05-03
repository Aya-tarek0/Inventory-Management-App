using InventorySystem.CQRS.Query.Reports;
using InventorySystem.DTO.Reports;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.CQRS.Handler.Reports
{
    public class GetTransactionForProductHandler : IRequestHandler<GetTransactionsForProductQuery, IEnumerable<TransactionHistoryDTO>>
    {
        private readonly IGenericRepository<InventoryTransaction> genericRepository;

        public GetTransactionForProductHandler(IGenericRepository<InventoryTransaction> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<IEnumerable<TransactionHistoryDTO>> Handle(GetTransactionsForProductQuery request, CancellationToken cancellationToken)
        {
            var transations = genericRepository.GetAll()
                                               .Include(e => e.Inventory)
                                               .ThenInclude(i => i.Product)
                                               .Include(e => e.User)
                                               .Where(e => e.Inventory.ProductId == request.ProductId)
                                               .Select(e => new TransactionHistoryDTO
                                               {
                                                  ProductName = e.Inventory.Product.Name,
                                                  transactionType = e.TransactionType,
                                                  UserName = e.User.UserName,
                                                  date = e.Date,
                                                  Category = e.Inventory.Product.Category,
                                                });

            var FilteredTransactions = transations;
            if (request.filter == Enum.Filter.Category && request.Category != null)
            {
                FilteredTransactions = transations.Where(e => e.Category == request.Category);
            }

            if (request.filter == Enum.Filter.DateRange && request.dateTime.HasValue)
            {
                FilteredTransactions = transations.Where(e => e.date > request.dateTime);
            }

            if (request.filter == Enum.Filter.TransactionType && request.TransactionType.HasValue)
            {
                FilteredTransactions = transations.Where(e => e.transactionType == request.TransactionType);
            }

            var list = await FilteredTransactions.ToListAsync();
          


            return list;
        }

    
    }
}
