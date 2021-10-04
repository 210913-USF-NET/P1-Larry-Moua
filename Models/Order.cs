using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public Order() {}
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public int PhotocardId { get; set; }
        public DateTime? DateandTime { get; set; }
        
        public override string ToString()
        {
            return $"CustomerId: {this.CustomerId} WarehouseId: {this.WarehouseId} PhotocardId: {this.PhotocardId}, Date {this.DateandTime}";
        }
    }
}