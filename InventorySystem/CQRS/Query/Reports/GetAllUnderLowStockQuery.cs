using InventorySystem.DTO.Reports;
using InventorySystem.Enum;
using MediatR;

namespace InventorySystem.CQRS.Query.Reports
{
    public class GetAllUnderLowStockQuery : IRequest<IEnumerable<ProductsUnderLow>>
    {
        public Filter filter { set; get; }

        public string Category { set; get; }
    }
}
