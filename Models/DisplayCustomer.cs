using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public static class DisplayCustomer
    {
        public static string Name {get; set; }
        public static string Warehouse {get; set; }
        public static int WarehouseId {get; set; }
        public static int CustomerId {get; set; }
        public static string Email {get; set; }
    }
}