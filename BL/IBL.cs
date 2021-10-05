using Models;
using System.Collections.Generic;
using DL;

namespace RBBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer custom);
        Customer UpdateCustomer(Customer customToUpdate, string input);
        List<Inventory> GetAllInventory();
        List<Photocard> GetAllPhotocard();
        Inventory UpdateInventory(Inventory inventoryToUpdate, int input, int input2);
        List<Order> GetAllOrders();
        Order AddOrder(Order ord, int input1, int input2, int input3);
        Inventory StockInventory(Inventory inventoryToStock, int input);
        void RemoveCustomer(int id);
    }
}