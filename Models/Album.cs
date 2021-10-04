using System;
using System.Collections.Generic;

namespace Models
{
    public class Album
    {
        public Album() {}
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
    }
}