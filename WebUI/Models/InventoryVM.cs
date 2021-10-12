using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class InventoryVM
    {
        public int Id { get; set; } // should equal to inventory id
        public string WarehouseName { get; set; }
        public string PhotocardSet { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
