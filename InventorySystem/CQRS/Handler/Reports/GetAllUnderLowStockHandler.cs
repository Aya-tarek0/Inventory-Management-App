using InventorySystem.CQRS.Query.Reports;
using InventorySystem.DTO.Reports;
using InventorySystem.Enum;
using InventorySystem.Interfaces;
using MediatR;

namespace InventorySystem.CQRS.Handler.Reports
{
    public class GetAllUnderLowStockHandler : IRequestHandler<GetAllUnderLowStockQuery,IEnumerable<ProductsUnderLow>>
    {
        private readonly IGenericRepository<Models.Inventory> genericRepository;

        public GetAllUnderLowStockHandler (IGenericRepository<Models.Inventory> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<IEnumerable<ProductsUnderLow>> Handle(GetAllUnderLowStockQuery request, CancellationToken cancellationToken)
        {
            var products = genericRepository.GetAll()
        .Where(e => e.Quantity < e.LowStockThreshold)
        .Select(e => new ProductsUnderLow
        {
            InventoryId = e.Id,
            ProductName = e.Product.Name,
           WareHouseName = e.Warehouse.Name,
          Category = e.Product.Category
          
         
        });
            var FilteredProducts = products;
            if (request.filter == Filter.Category)
            {
             FilteredProducts=  products.Where(e => e.Category == request.Category);
            }

          return FilteredProducts.ToList();
    }
    }
}
