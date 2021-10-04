using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Idol
    {
        public Idol()
        {
            Photocards = new HashSet<Photocard>();
        }

        public int Id { get; set; }
        public string StageName { get; set; }
        public int GroupId { get; set; }

        public virtual Artist Group { get; set; }
        public virtual ICollection<Photocard> Photocards { get; set; }
    }
}
