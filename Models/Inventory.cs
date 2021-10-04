using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Inventory
    {
        public Inventory() {}

        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int PhotocardId { get; set; }

        private int _stock;

        public int Stock
        {
            get { return _stock;}
            set
            {
                if (value < 0 || value > 9999)
                {
                    throw new InputInvalidException("Stock must be a positive number and below 10,000.");
                }
                else
                {
                    _stock = value;
                }
            }
        }

        public string WarehouseName {get; set;}
        public string Photocard {get; set;}

        public override string ToString()
        {
            return $"Warehouse: {this.WarehouseId} Photocard: {this.PhotocardId}, Stock {this.Stock}";
        }
    }
}