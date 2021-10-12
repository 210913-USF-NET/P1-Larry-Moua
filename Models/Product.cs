using System;
using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public Product() {}

        public Product(int inventoryId, int warehouseId, int photocardId, string setName, decimal price, int stock) {
            this.inventoryId = inventoryId;
            this.warehouseId = warehouseId;
            this.photocardId = photocardId;
            this.setName = setName;
            this.price = price;
            this.stock = stock;
        }  

        public int inventoryId { get; set; }
        public int warehouseId {get; set;}
        public int photocardId {get; set;}
        public string setName {get; set;}
        public decimal price {get; set;}
        public int stock { get; set; }

        public override string ToString()
        {
            return $"SetName: {this.setName} Price: {price}";
        }

        public int ReturnPhotoId()
        {
            return this.photocardId;
        }

        public int ReturnWarehouseId()
        {
            return this.warehouseId;
        }
    }
}