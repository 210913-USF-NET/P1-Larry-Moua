using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private Entity.kpopsnapshotdbContext _context;

        public DBRepo(Entity.kpopsnapshotdbContext context)
        {
            _context = context;
        }

        public Model.Customer AddCustomer(Model.Customer custom)
        {
            Entity.Customer customToAdd = new Entity.Customer(){
                Name = custom.Name,
                Email = custom.Email,
                Address = custom.Address,
                Points = 0
            };

            customToAdd = _context.Add(customToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customer()
            {
                Id = customToAdd.Id,
                Name = customToAdd.Name,
                Email = customToAdd.Email,
                Address = customToAdd.Address,
                Points = customToAdd.Points
            };

        }

        public Model.Customer UpdateCustomer(Model.Customer customerToUpdate, string input)
        {
            Entity.Customer customToUpdate = (from c in _context.Customers
                where c.Email == customerToUpdate.Email
                select c)
                .SingleOrDefault();

            customToUpdate.Name = input;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customer() {
                Name = customerToUpdate.Name
            };
        }

        public Model.Order AddOrder(Model.Order ord, int input1, int input2, int input3)
        {
            Entity.Order orderToAdd = new Entity.Order(){
                CustomerId = input1,
                WarehouseId = input2,
                PhotocardId = input3
            };

            orderToAdd = _context.Add(orderToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Order()
            {
                Id = orderToAdd.Id,
                CustomerId = orderToAdd.CustomerId,
                WarehouseId = orderToAdd.WarehouseId,
                PhotocardId = orderToAdd.PhotocardId,
                DateandTime = orderToAdd.DateandTime
            };
        }

        public List<Model.Order> GetAllOrders()
        {
            return _context.Orders.Select(
                orders => new Model.Order()
                {
                    Id = orders.Id,
                    CustomerId = orders.CustomerId,
                    WarehouseId = orders.WarehouseId,
                    PhotocardId = orders.PhotocardId,
                    DateandTime = orders.DateandTime
                }
            ).ToList();
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                customers => new Model.Customer()
                {
                    Id = customers.Id,
                    Name = customers.Name,
                    Email = customers.Email,
                    Address = customers.Address,
                    Points = customers.Points
                }
            ).ToList();
        }

        public List<Model.Inventory> GetAllInventory()
        {
            return _context.Inventories.Select(
                inventories => new Model.Inventory()
                {
                    Id = inventories.Id,
                    WarehouseId = inventories.WarehouseId,
                    PhotocardId = inventories.PhotocardId,
                    Stock = inventories.Stock
                }
                ).ToList();

        }

        public Model.Inventory UpdateInventory(Model.Inventory inventoryToUpdate, int input, int input2)
        {
            Entity.Inventory inventToUpdate = (from i in _context.Inventories
            where i.WarehouseId == input && i.PhotocardId == input2
            select i)
            .SingleOrDefault();

            inventToUpdate.Stock--;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            
            return new Model.Inventory() {
                Stock = inventoryToUpdate.Stock
            };
        }

        public Model.Inventory StockInventory(Model.Inventory inventoryToStock, int input)
        {
            Entity.Inventory inventToStock = new Entity.Inventory()
            {
                Id = inventoryToStock.Id,
                WarehouseId = inventoryToStock.WarehouseId,
                PhotocardId = inventoryToStock.PhotocardId,
                Stock = inventoryToStock.Stock
            };

            inventToStock.Stock = input;
            inventToStock = _context.Inventories.Update(inventToStock).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Inventory()
            {
                Id = inventToStock.Id,
                WarehouseId = inventToStock.WarehouseId,
                PhotocardId = inventToStock.PhotocardId,
                Stock = inventToStock.Stock
            };
        }

        public List<Model.Photocard> GetAllPhotocard()
        {
            return _context.Photocards.Select(
                photocard => new Model.Photocard()
                {
                    Id = photocard.Id,
                    SetId = photocard.SetId,
                    Price = photocard.Price
                }
            ).ToList();
        }
    }
}
