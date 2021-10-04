using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public int PhotocardId { get; set; }
        public DateTime? DateandTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Photocard Photocard { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
