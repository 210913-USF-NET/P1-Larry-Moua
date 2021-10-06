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

        public Order AddOrder(Order ord, int input1, int input2, int input3)
        {

            ord = _context.Add(ord).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Order()
            {
                Id = ord.Id,
                CustomerId = ord.CustomerId,
                WarehouseId = ord.WarehouseId,
                PhotocardId = ord.PhotocardId,
                DateandTime = ord.DateandTime
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

        public void RemoveCustomer(int id)
        {
            _context.Customer.Remove(GetOneCustomerById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
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

        public Inventory UpdateInventory(Inventory inventoryToUpdate, int input, int input2)
        {

            inventoryToUpdate.Stock--; // this only subtracts one, need to change where it subtracts the specified amount based on parameter
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            
            return new Inventory() {
                Stock = inventoryToUpdate.Stock
            };
        }

        public Inventory StockInventory(Inventory inventoryToStock, int input)
        {

            inventoryToStock.Stock = input;
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

        public List<Photocard> GetAllPhotocard()
        {
            return _context.Photocard.Select(
                photocard => new Photocard()
                {
                    Id = photocard.Id,
                    SetId = photocard.SetId,
                    Price = photocard.Price
                }
            ).ToList();
        }
    }
}
