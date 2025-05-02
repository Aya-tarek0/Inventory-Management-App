using InventorySystem.DTO;
using InventorySystem.Enum;
using MediatR;

namespace InventorySystem.CQRS.Commands.Inventory
{
    public class TransferStockCommand :IRequest
    {
  
        public int Stock { set; get; }

        public int fromWareHouse { set; get; }

        public int ToWareHouse { set; get; }
        public int ProductId{ set; get; }



    }
}
