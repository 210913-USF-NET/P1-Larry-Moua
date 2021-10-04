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

        public Customer UpdateCustomer(Customer customerToUpdate, string input)
        {

            customerToUpdate.Name = input;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customer() {
                Name = customerToUpdate.Name
            };
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
