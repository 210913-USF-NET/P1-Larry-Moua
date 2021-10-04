using System;
using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public Product() {}

        public Product(int warehouseId, int photocardId, string setName, decimal price) {
            this.warehouseId = warehouseId;
            this.photocardId = photocardId;
            this.setName = setName;
            this.price = price;
        }  

        public int warehouseId {get; set;}
        public int photocardId {get; set;}
        public string setName {get; set;}
        public decimal price {get; set;}

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