﻿using InventorySystem.DTO.Inventories;
using MediatR;

namespace InventorySystem.CQRS.Commands.Inventory
{
    public class RemoveStockCommand : IRequest<UpdateInventoryDto>
    {
        public UpdateInventoryDto UpdateInventoryDto { set; get; }
        public int quantity { set; get; }
        public int InventoryId { set; get; }
    }
}
