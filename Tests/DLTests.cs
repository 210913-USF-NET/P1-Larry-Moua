using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Xunit;
using Models;

namespace Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<RRDBContext> options;

        public DLTests()
        {
            options = new DbContextOptionsBuilder<RRDBContext>()
                        .UseSqlite("Filename=Test.db").Options;
            Seed();
        }

        [Fact]
        public void AddingACustomerShouldAddACustomer()
        {
            using (var context = new RRDBContext(options))
            {
                IRepo repo = new DBRepo(context);
                Customer customToAdd = new Customer()
                {
                    Id = 4,
                    Name = "Buzz Lightyear",
                    Address = "1234 Buzz Way",
                    Email = "buzz@gmail.com",
                    Points = 0
                };

                repo.AddCustomer(customToAdd);
            }

            using (var context = new RRDBContext(options))
            {
                Customer custom = context.Customer.FirstOrDefault(c => c.Id == 4);

                Assert.NotNull(custom);
                Assert.Equal("Buzz Lightyear", custom.Name);
                Assert.Equal("1234 Buzz Way", custom.Address);
                Assert.Equal("buzz@gmail.com", custom.Email);
                Assert.Equal(0, custom.Points);
            }
        }

        [Fact]
        public void AddingAnArtistShouldAddAnArtist()
        {
            using (var context = new RRDBContext(options))
            {
                IRepo repo = new DBRepo(context);
                Artist artToAdd = new Artist()
                {
                    Id = 4,
                    GroupName = "TOMORROW X TOGETHER"
                };

                repo.AddArtist(artToAdd);
            }

            using (var context = new RRDBContext(options))
            {
                Artist artToAdd = context.Artist.FirstOrDefault(c => c.Id == 4);

                Assert.NotNull(artToAdd);
                Assert.Equal("TOMORROW X TOGETHER", artToAdd.GroupName);
            }
        }

        [Fact]
        public void AddingAnAlbumShouldAddAnAlbum()
        {
            using (var context = new RRDBContext(options))
            {
                IRepo repo = new DBRepo(context);
                Album albToAdd = new Album()
                {
                    Id = 4,
                    AlbumName = "THE SIX",
                    ArtistId = 2
                };

                repo.AddAlbum(albToAdd);
            }

            using (var context = new RRDBContext(options))
            {
                Album albToAdd = context.Album.FirstOrDefault(c => c.Id == 4);

                Assert.NotNull(albToAdd);
                Assert.Equal("THE SIX", albToAdd.AlbumName);
                Assert.Equal(2, albToAdd.ArtistId);
            }
        }

        [Fact]
        public void AddingAnIdolShouldAddAnIdol()
        {
            using (var context = new RRDBContext(options))
            {
                IRepo repo = new DBRepo(context);
                Idol idoToAdd = new Idol()
                {
                    Id = 4,
                    StageName = "Sika",
                    GroupId = 2
                };

                repo.AddIdol(idoToAdd);
            }

            using (var context = new RRDBContext(options))
            {
                Idol idoToAdd = context.Idol.FirstOrDefault(c => c.Id == 4);

                Assert.NotNull(idoToAdd);
                Assert.Equal("Sika", idoToAdd.StageName);
                Assert.Equal(2, idoToAdd.GroupId);
            }
        }

        [Fact]
        public void AddingAPhotocardShouldAddAPhotocard()
        {
            using (var context = new RRDBContext(options))
            {
                IRepo repo = new DBRepo(context);
                Photocard photoToAdd = new Photocard()
                {
                    Id = 4,
                    StageNameId = 1,
                    GroupNameId = 2,
                    AlbumId = 1,
                    SetId = "AE-OndaA",
                    Price = 4.99m,
                    PointPrice = 100,
                    PointValue = 10
                };

                repo.AddPhotocard(photoToAdd);
            }

            using (var context = new RRDBContext(options))
            {
                Photocard photoToAdd = context.Photocard.FirstOrDefault(c => c.Id == 4);

                Assert.NotNull(photoToAdd);
                Assert.Equal(1, photoToAdd.StageNameId);
                Assert.Equal(2, photoToAdd.GroupNameId);
                Assert.Equal(1, photoToAdd.AlbumId);
                Assert.Equal("AE-OndaA", photoToAdd.SetId);
                Assert.Equal(4.99m, photoToAdd.Price);
                Assert.Equal(100, photoToAdd.PointPrice);
                Assert.Equal(10, photoToAdd.PointValue);

            }
        }

        [Fact]
        public void AddingAWarehouseShouldAddAWarehouse()
        {
            using (var context = new RRDBContext(options))
            {
                IRepo repo = new DBRepo(context);
                Warehouse wareToAdd = new Warehouse()
                {
                    Id = 4,
                    Name = "WarehouseCN",
                    Location = "Beijing, China"
                };

                repo.AddWarehouse(wareToAdd);
            }

            using (var context = new RRDBContext(options))
            {
                Warehouse wareToAdd = context.Warehouse.FirstOrDefault(c => c.Id == 4);

                Assert.NotNull(wareToAdd);
                Assert.Equal(4, wareToAdd.Id);
                Assert.Equal("WarehouseCN", wareToAdd.Name);
                Assert.Equal("Beijing, China", wareToAdd.Location);

            }
        }

        [Fact]
        public void RemovingArtistShouldRemoveArtist()
        {
            using (var context = new RRDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                repo.RemoveArtist(2);

                var artById = repo.GetOneArtistById(2);

                //Assert
                Assert.Null(artById);
            }
        }

        [Fact]
        public void RemovingCustomerShouldRemoveCustomer()
        {
            using (var context = new RRDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                repo.RemoveCustomer(3);

                var custById = repo.GetOneCustomerById(3);

                //Assert
                Assert.Null(custById);
            }
        }

        [Fact]
        public void GetAllCustomersShouldGetAllCustomers()
        {
            using (var context = new RRDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var customers = repo.GetAllCustomers();

                //Assert
                Assert.Equal(3, customers.Count);
            }
        }

        [Fact]
        public void GetAllArtistShouldGetAllArtists()
        {
            using (var context = new RRDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var artists = repo.GetAllArtist();

                //Assert
                Assert.Single(artists);
            }
        }

        [Fact]
        public void AddingInventoryShouldAddInventory()
        {
            using (var context = new RRDBContext(options))
            {
                IRepo repo = new DBRepo(context);
                Inventory inventToAdd = new Inventory()
                {
                    Id = 4,
                    WarehouseId = 1,
                    PhotocardId = 2,
                    Stock = 100
                };

                repo.AddInventory(inventToAdd);
            }

            using (var context = new RRDBContext(options))
            {
                Inventory inventToAdd = context.Inventory.FirstOrDefault(c => c.Id == 4);

                Assert.NotNull(inventToAdd);
                Assert.Equal(4, inventToAdd.Id);
                Assert.Equal(1, inventToAdd.WarehouseId);
                Assert.Equal(2, inventToAdd.PhotocardId);
                Assert.Equal(100, inventToAdd.Stock);

            }
        }

        private void Seed()
        {
            using (var context = new RRDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Customer.AddRange(
                    new Customer()
                    {
                        Id = 1,
                        Name = "Chaelin",
                        Address = "1234 Chaelin Way",
                        Email = "chae@gmail.com",
                        Points = 0
                    },
                    new Customer()
                    {
                        Id = 2,
                        Name = "Jiwon",
                        Address = "1234 Jiwon Dr",
                        Email = "jiwon@gmail.com",
                        Points = 0
                    },
                    new Customer()
                    {
                        Id = 3,
                        Name = "Suji",
                        Address = "1234 Idolmaster Way",
                        Email = "suji@gmail.com",
                        Points = 0
                    });

                context.Artist.Add(
                    new Artist()
                    {
                        Id = 2,
                        GroupName = "Blackpink"
                    });

                context.SaveChanges();
            }   
        }
    }
}
