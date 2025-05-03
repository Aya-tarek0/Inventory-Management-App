using InventorySystem.CQRS.Query.Reports;
using InventorySystem.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        public IMediator Mediator { get; }

        public ReportsController(IMediator mediator)
        {
            Mediator = mediator;
        }
        [HttpGet("under-low-stock")]
        public async Task<IActionResult> GetProductsUnderLowStock([FromQuery] Filter filter, [FromQuery] string? category)
        {
            var query = new GetAllUnderLowStockQuery
            {
                filter = filter,
                Category = category
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("Transaction-History/{ProductId}")]
        public async Task<IActionResult> GetTransactionsForProduct([FromQuery] Filter filter, [FromQuery] string? category , DateTime? date , TransactionType? transactionType, int ProductId)
        {
            var query = new GetTransactionsForProductQuery
            {
                filter = filter,
                Category = category,
                dateTime = date,
                TransactionType = transactionType,
                ProductId = ProductId
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

