using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Photocard
    {
        public Photocard()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int StageNameId { get; set; }
        public int GroupNameId { get; set; }
        public int AlbumId { get; set; }
        public string SetId { get; set; }
        public decimal Price { get; set; }
        public int PointPrice { get; set; }
        public int PointValue { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist GroupName { get; set; }
        public virtual Idol StageName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
