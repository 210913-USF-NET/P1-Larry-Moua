using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int PhotocardId { get; set; }
        public int Stock { get; set; }

        public virtual Photocard Photocard { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
