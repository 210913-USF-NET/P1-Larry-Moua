using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public string WarehouseName { get; set; }
        public string PhotocardName { get; set; }
        public DateTime? DateandTime { get; set; }
    }
}
