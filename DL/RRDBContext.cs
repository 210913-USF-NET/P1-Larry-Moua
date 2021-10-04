using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace DL
{
    public class RRDBContext : DbContext
    {
        public RRDBContext() : base() { }
        public RRDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Idol> Idol { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Photocard> Photocard { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

    }
}
