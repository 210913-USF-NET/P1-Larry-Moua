using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        private RRDBContext _context;
        public DBRepo(RRDBContext context)
        {
            _context = context;
        }

        //----------CUSTOMER METHODS----------
        public Customer AddCustomer(Customer custom)
        {

            custom = _context.Add(custom).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return custom;

        }
        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            Customer customToUpdate = new Customer()
            {
                Id = customerToUpdate.Id,
                Name = customerToUpdate.Name,
                Email = customerToUpdate.Email,
                Address = customerToUpdate.Address,
                Points = customerToUpdate.Points
            };

            customToUpdate = _context.Customer.Update(customToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customer() {
                Id = customToUpdate.Id,
                Name = customToUpdate.Name,
                Email = customToUpdate.Email,
                Address = customToUpdate.Address,
                Points = customToUpdate.Points
            };
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customer.Select(
                customer => new Customer()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Address = customer.Address,
                    Points = customer.Points
                }
            ).ToList();
        }
        public Customer GetOneCustomerById(int id)
        {
            return _context.Customer
                    .AsNoTracking()
                    .Include(c => c.Order)
                    .FirstOrDefault(c => c.Id == id);
        }
        public Customer GetOneCustomerByEmail(string email)
        {
            return _context.Customer
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Email == email);
        }
        public void RemoveCustomer(int id)
        {
            _context.Customer.Remove(GetOneCustomerById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        //----------ARTIST METHODS----------
        public Artist AddArtist(Artist art)
        {

            art = _context.Add(art).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return art;
           
        }
        public List<Artist> GetAllArtist()
        {
            return _context.Artist.Select(
                artist => new Artist()
                {
                    Id = artist.Id,
                    GroupName = artist.GroupName
                }
            ).ToList();
        }
        public Artist UpdateArtist(Artist artistToUpdate)
        {
            Artist artToUpdate = new Artist()
            {
                Id = artistToUpdate.Id,
                GroupName = artistToUpdate.GroupName
            };

            artToUpdate = _context.Artist.Update(artToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Artist()
            {
                Id = artToUpdate.Id,
                GroupName = artToUpdate.GroupName
            };
        }
        public Artist GetOneArtistById(int id)
        {
            return _context.Artist
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
        }
        public void RemoveArtist(int id)
        {
            _context.Artist.Remove(GetOneArtistById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        //----------ALBUM METHODS----------
        public Album AddAlbum(Album album)
        {

            album = _context.Add(album).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return album;

        }
        public List<Album> GetAllAlbum()
        {
            return _context.Album.Select(
                album => new Album()
                {
                    Id = album.Id,
                    AlbumName = album.AlbumName,
                    ArtistId = album.ArtistId
                }
            ).ToList();
        }
        public Album UpdateAlbum(Album albumToUpdate)
        {
            Album albToUpdate = new Album()
            {
                Id = albumToUpdate.Id,
                AlbumName = albumToUpdate.AlbumName,
                ArtistId = albumToUpdate.ArtistId
            };

            albToUpdate = _context.Album.Update(albToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Album()
            {
                Id = albToUpdate.Id,
                AlbumName = albToUpdate.AlbumName,
                ArtistId = albToUpdate.ArtistId
            };
        }
        public Album GetOneAlbumById(int id)
        {
            return _context.Album
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
        }
        public void RemoveAlbum(int id)
        {
            _context.Album.Remove(GetOneAlbumById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        //----------IDOL METHODS----------
        public Idol AddIdol(Idol idol)
        {

            idol = _context.Add(idol).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return idol;

        }
        public List<Idol> GetAllIdol()
        {
            return _context.Idol.Select(
                idol => new Idol()
                {
                    Id = idol.Id,
                    StageName = idol.StageName,
                    GroupId = idol.GroupId
                }
            ).ToList();
        }
        public Idol UpdateIdol(Idol idolToUpdate)
        {
            Idol idoToUpdate = new Idol()
            {
                Id = idolToUpdate.Id,
                StageName = idolToUpdate.StageName,
                GroupId = idolToUpdate.GroupId
            };

            idoToUpdate = _context.Idol.Update(idoToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Idol()
            {
                Id = idoToUpdate.Id,
                StageName = idoToUpdate.StageName,
                GroupId = idoToUpdate.GroupId
            };
        }
        public Idol GetOneIdolById(int id)
        {
            return _context.Idol
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
        }
        public void RemoveIdol(int id)
        {
            _context.Idol.Remove(GetOneIdolById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        //----------PHOTOCARD METHODS----------
        public Photocard AddPhotocard(Photocard photocard)
        {

            photocard = _context.Add(photocard).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return photocard;

        }
        public List<Photocard> GetAllPhotocard()
        {
            return _context.Photocard.Select(
                photocard => new Photocard()
                {
                    Id = photocard.Id,
                    StageNameId = photocard.StageNameId,
                    GroupNameId = photocard.GroupNameId,
                    AlbumId = photocard.AlbumId,
                    SetId = photocard.SetId,
                    Price = photocard.Price,
                    PointPrice = photocard.PointPrice,
                    PointValue = photocard.PointValue
                }
            ).ToList();
        }
        public Photocard UpdatePhotocard(Photocard photocardToUpdate)
        {
            Photocard photoToUpdate = new Photocard()
            {
                Id = photocardToUpdate.Id,
                StageNameId = photocardToUpdate.StageNameId,
                GroupNameId = photocardToUpdate.GroupNameId,
                AlbumId = photocardToUpdate.AlbumId,
                SetId = photocardToUpdate.SetId,
                Price = photocardToUpdate.Price,
                PointPrice = photocardToUpdate.PointPrice,
                PointValue = photocardToUpdate.PointValue
            };

            photoToUpdate = _context.Photocard.Update(photoToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Photocard()
            {
                Id = photoToUpdate.Id,
                StageNameId = photoToUpdate.StageNameId,
                GroupNameId = photoToUpdate.GroupNameId,
                AlbumId = photoToUpdate.AlbumId,
                SetId = photoToUpdate.SetId,
                Price = photoToUpdate.Price,
                PointPrice = photoToUpdate.PointPrice,
                PointValue = photoToUpdate.PointValue
            };
        }
        public Photocard GetOnePhotocardById(int id)
        {
            return _context.Photocard
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
        }
        public void RemovePhotocard(int id)
        {
            _context.Photocard.Remove(GetOnePhotocardById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        //----------

        //----------WAREHOUSE METHODS----------
        public Warehouse AddWarehouse(Warehouse warehouse)
        {

            warehouse = _context.Add(warehouse).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return warehouse;

        }
        public List<Warehouse> GetAllWarehouse()
        {
            return _context.Warehouse.Select(
                warehouse => new Warehouse()
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    Location = warehouse.Location
                }
            ).ToList();
        }
        public Warehouse UpdateWarehouse(Warehouse warehouseToUpdate)
        {
            Warehouse wareToUpdate = new Warehouse()
            {
                Id = warehouseToUpdate.Id,
                Name = warehouseToUpdate.Name,
                Location = warehouseToUpdate.Location
            };

            wareToUpdate = _context.Warehouse.Update(wareToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Warehouse()
            {
                Id = wareToUpdate.Id,
                Name = wareToUpdate.Name,
                Location = wareToUpdate.Location
            };
        }
        public Warehouse GetOneWarehouseById(int id)
        {
            return _context.Warehouse
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
        }
        public void RemoveWarehouse(int id)
        {
            _context.Warehouse.Remove(GetOneWarehouseById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        //----------

        //----------ORDER METHODS----------
        public Order AddOrder(Order ord, int input1, int input2, int input3)
        {
            Order orderToAdd = new Order()
            {
                CustomerId = input1,
                WarehouseId = input2,
                PhotocardId = input3,
                DateandTime = default(DateTime)
            };

            orderToAdd = _context.Add(orderToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Order()
            {
                Id = orderToAdd.Id,
                CustomerId = orderToAdd.CustomerId,
                WarehouseId = orderToAdd.WarehouseId,
                PhotocardId = orderToAdd.PhotocardId,
                DateandTime = default(DateTime)
            };
        }
        public List<Order> GetAllOrders()
        {
            return _context.Order.Select(
                order => new Order()
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    WarehouseId = order.WarehouseId,
                    PhotocardId = order.PhotocardId,
                    DateandTime = order.DateandTime
                }
            ).ToList();
        }
        //----------

        //----------INVENTORY METHODS----------
        public Inventory AddInventory(Inventory invent)
        {
            invent = _context.Add(invent).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return invent;
        }
        public List<Inventory> GetAllInventory()
        {
            return _context.Inventory.Select(
                inventory => new Inventory()
                {
                    Id = inventory.Id,
                    WarehouseId = inventory.WarehouseId,
                    PhotocardId = inventory.PhotocardId,
                    Stock = inventory.Stock
                }
                ).ToList();

        }
        public Inventory UpdateInventory(Inventory inventoryToUpdate)
        {
            Inventory inventToUpdate = new Inventory()
            {
                Id = inventoryToUpdate.Id,
                WarehouseId = inventoryToUpdate.WarehouseId,
                PhotocardId = inventoryToUpdate.PhotocardId,
                Stock = inventoryToUpdate.Stock
            };

            //inventoryToUpdate.Stock--; // this only subtracts one, need to change where it subtracts the specified amount based on parameter
            inventToUpdate = _context.Inventory.Update(inventToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            
            return new Inventory() {
                Id = inventToUpdate.Id,
                WarehouseId = inventToUpdate.WarehouseId,
                PhotocardId = inventToUpdate.PhotocardId,
                Stock = inventToUpdate.Stock
            };
        }
        public Inventory StockInventory(Inventory inventoryToStock, int input)
        {

            inventoryToStock.Stock--;
            inventoryToStock = _context.Inventory.Update(inventoryToStock).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Inventory()
            {
                Id = inventoryToStock.Id,
                WarehouseId = inventoryToStock.WarehouseId,
                PhotocardId = inventoryToStock.PhotocardId,
                Stock = inventoryToStock.Stock
            };
        }
        public Inventory GetOneInventoryById(int id)
        {
            return _context.Inventory
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
        }
        public void RemoveInventory(int id)
        {
            _context.Inventory.Remove(GetOneInventoryById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        //----------


    }
}
