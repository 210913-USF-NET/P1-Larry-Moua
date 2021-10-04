using System;
using System.Collections.Generic;

namespace Models
{
    public class Photocard
    {
        public Photocard() {}
        public int Id { get; set; }
        public int StageNameId { get; set; }
        public int GroupNameId { get; set; }
        public int AlbumId { get; set; }
        public string SetId { get; set; }
        public decimal Price { get; set; }
        public int PointPrice { get; set; }
        public int PointValue { get; set; }
    }
}