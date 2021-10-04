using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
