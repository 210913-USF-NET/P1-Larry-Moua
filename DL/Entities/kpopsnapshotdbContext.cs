using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL.Entities
{
    public partial class kpopsnapshotdbContext : DbContext
    {
        public kpopsnapshotdbContext()
        {
        }

        public kpopsnapshotdbContext(DbContextOptions<kpopsnapshotdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Idol> Idols { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Photocard> Photocards { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Album__ArtistID__4B7734FF");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Idol>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StageName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Idols)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Idols__GroupID__489AC854");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.PhotocardId).HasColumnName("PhotocardID");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.Photocard)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.PhotocardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Photo__55F4C372");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Wareh__55009F39");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateandTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__5D95E53A");

                entity.HasOne(d => d.Photocard)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PhotocardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Photocar__5F7E2DAC");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Warehous__5E8A0973");
            });

            modelBuilder.Entity<Photocard>(entity =>
            {
                entity.ToTable("Photocard");

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.GroupNameId).HasColumnName("GroupNameID");

                entity.Property(e => e.Price).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SetId)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("SetID");

                entity.Property(e => e.StageNameId).HasColumnName("StageNameID");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Photocards)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Photocard__Album__503BEA1C");

                entity.HasOne(d => d.GroupName)
                    .WithMany(p => p.Photocards)
                    .HasForeignKey(d => d.GroupNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Photocard__Group__4F47C5E3");

                entity.HasOne(d => d.StageName)
                    .WithMany(p => p.Photocards)
                    .HasForeignKey(d => d.StageNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Photocard__Stage__4E53A1AA");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
