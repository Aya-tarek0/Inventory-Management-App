﻿using InventorySystem.Models;

namespace InventorySystem.DTO.Products
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { set; get; }
        public string Category { get; set; }

    }
}
