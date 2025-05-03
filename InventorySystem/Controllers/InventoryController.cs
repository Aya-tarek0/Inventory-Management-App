using InventorySystem.CQRS.Commands.Inventory;
using InventorySystem.CQRS.Commands.Products;
using InventorySystem.CQRS.Orchestrators;
using InventorySystem.CQRS.Query.Inventory;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO;
using InventorySystem.DTO.Inventories;
using InventorySystem.DTO.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        
            public IMediator Mediator { get; }

            public InventoryController(IMediator mediator)
            {
                Mediator = mediator;
            }


            #region Get By Id


            [HttpGet("{id}")]
            public async Task<ResponseDto<InventoryDto>> GetById(int id)
            {
                try
                {
                    var inventory = await Mediator.Send(new GetInventoryByIdQuery { Id = id });

                    if (inventory == null)
                        return ResponseDto<InventoryDto>.Error(Enum.ErrorCode.NotFound, "Inventory Not Found");

                    return ResponseDto<InventoryDto>.Succeded(inventory, "Get Inventory Succefully");
                }
                catch (Exception ex)
                {
                    return ResponseDto<InventoryDto>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
                }
            }
            #endregion


            #region Get All
            [HttpGet]
            public async Task<ResponseDto<IEnumerable<InventoryDto>>> GetAllInventories()
            {
                try
                {
                    var Inventories = await Mediator.Send(new GetAllInventoryQuery());

                    if (Inventories == null)
                        return ResponseDto<IEnumerable<InventoryDto>>.Error(Enum.ErrorCode.NotFound, "The List Is Empty");

                    return ResponseDto<IEnumerable<InventoryDto>>.Succeded(Inventories, "Get All Successfully");
                }
                catch (Exception ex)
                {
                    return ResponseDto<IEnumerable<InventoryDto>>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
                }
            }

            #endregion


            #region Add
            [HttpPost]
            [Authorize(Roles ="Admin")]
            public async Task<ResponseDto<InventoryDto>> AddInventory([FromBody] InventoryDto dto)
            {
                try
                {
                    var newInventory = await Mediator.Send(new AddInventoryCommand { InventoryDto = dto });

                    return ResponseDto<InventoryDto>.Succeded(newInventory, "Inventory Added");
                }
                catch (Exception ex)
                {
                    return ResponseDto<InventoryDto>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
                }
            }
            #endregion


            #region Update
            [HttpPut("{id}")]

            public async Task<ResponseDto<InventoryDto>> UpdateProduct([FromBody]InventoryDto dto, int id)
            {
                try
                {
                    var newProduct = await Mediator.Send(new UpdateInventoryCommand { InventoryDto = dto, Id = id });

                    return ResponseDto<InventoryDto>.Succeded(new InventoryDto {ProductId = dto.ProductId ,Quantity = dto.Quantity , WarehouseId = dto.WarehouseId , LowStockThreshold = dto.LowStockThreshold}, "Updated Succecfully");
                }
                catch (Exception ex)
                {
                    return ResponseDto<InventoryDto>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
                }

            }

            #endregion


            #region Delete
            [HttpDelete("{id}")]

            public async Task<ResponseDto<String>> DeleteInventory(int id)
            {
                try
                {
                    var deleted = await Mediator.Send(new DeleteInventoryCommand { Id = id });

                    return ResponseDto<string>.Succeded(" Deleted Successfully");
                }
                catch (Exception ex)
                {
                    return ResponseDto<string>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
                }
            }
        #endregion

        #region AddNewStock
        [HttpPost("add-stock")]
        [Authorize(Roles ="Admin")]
        public async Task<ResponseDto<TransactionDto>> AddStock([FromBody] AddStockOrchestratorCommand dto)
        {
            try
            {
                var result = await Mediator.Send(dto);
                return ResponseDto<TransactionDto>.Succeded(result, "Stock added and transaction recorded successfully");
            }
            catch (Exception ex)
            {
                return ResponseDto<TransactionDto>.Error(Enum.ErrorCode.UnExcepectedError,ex.Message);
            }
        }

        #endregion

        #region Remove Stock
        [HttpPost("Remove-stock")]
        [Authorize(Roles = "Admin")]

        public async Task<ResponseDto<TransactionDto>> RemoveStock([FromBody] RemoveStockOrcesrtrator dto)
        {
            try
            {
                var result = await Mediator.Send(dto);
                return ResponseDto<TransactionDto>.Succeded(result, "Stock Removed and transaction recorded successfully");
            }
            catch (Exception ex)
            {
                return ResponseDto<TransactionDto>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
            }
        }
        #endregion

        #region transfer Stock
        [HttpPost("Transfer-stock")]
        [Authorize(Roles = "Admin")]

        public async Task<ResponseDto<AddTransferTransactionDTO>> TransferStock([FromBody] TransferStockOrchestrator dto)
        {
            try
            {
                var result = await Mediator.Send(dto);
                return ResponseDto<AddTransferTransactionDTO>.Succeded(result, "Stock Transfered and transaction recorded successfully");
            }
            catch (Exception ex)
            {
                return ResponseDto<AddTransferTransactionDTO>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
            }
        }

        #endregion




    }
}
