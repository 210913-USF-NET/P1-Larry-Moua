using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class PhotocardVM
    {
        public int Id { get; set; }
        public string StageName { get; set; }
        public string GroupName { get; set; }
        public string AlbumName { get; set; }
        public string SetId { get; set; }
        public decimal Price { get; set; }
    }
}
