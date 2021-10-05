using System;
using Models;
using System.Collections.Generic;
using DL;

namespace RBBL
{
    public class BL : IBL
    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public List<Inventory> GetAllInventory()
        {
            return _repo.GetAllInventory();
        }

        public Customer AddCustomer(Customer custom)
        {
            return _repo.AddCustomer(custom);
        }

        public Customer UpdateCustomer(Customer customToUpdate, string input)
        {
            return _repo.UpdateCustomer(customToUpdate, input);
        }

        public List<Photocard> GetAllPhotocard()
        {
            return _repo.GetAllPhotocard();
        }

        public Inventory UpdateInventory(Inventory inventoryToUpdate, int input, int input2)
        {
            return _repo.UpdateInventory(inventoryToUpdate, input, input2);
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public Order AddOrder(Order ord, int input1, int input2, int input3)
        {
            return _repo.AddOrder(ord, input1, input2, input3);
        }

        public Inventory StockInventory(Inventory inventoryToStock, int input)
        {
            return _repo.StockInventory(inventoryToStock, input);
        }

        public void RemoveCustomer(int id)
        {
            _repo.RemoveCustomer(id);
        }

    }
}
