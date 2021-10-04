using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Album
    {
        public Album()
        {
            Photocards = new HashSet<Photocard>();
        }

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Photocard> Photocards { get; set; }
    }
}
