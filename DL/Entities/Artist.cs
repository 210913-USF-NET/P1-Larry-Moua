using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            Idols = new HashSet<Idol>();
            Photocards = new HashSet<Photocard>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Idol> Idols { get; set; }
        public virtual ICollection<Photocard> Photocards { get; set; }
    }
}
