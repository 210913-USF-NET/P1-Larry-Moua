using Models;
using System.Collections.Generic;
using DL;

namespace RBBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer custom);
        Customer UpdateCustomer(Customer customToUpdate);
        Artist AddArtist(Artist art);
        List<Artist> GetAllArtist();
        Artist UpdateArtist(Artist artistToUpdate);
        List<Inventory> GetAllInventory();
        List<Photocard> GetAllPhotocard();
        Inventory UpdateInventory(Inventory inventoryToUpdate);
        List<Order> GetAllOrders();
        Order AddOrder(Order ord, int input1, int input2, int input3);
        Inventory StockInventory(Inventory inventoryToStock, int input);
        void RemoveCustomer(int id);
        Customer GetOneCustomerById(int id);
        Customer GetOneCustomerByEmail(string email);
        Album AddAlbum(Album album);
        List<Album> GetAllAlbum();
        Album UpdateAlbum(Album albumToUpdate);
        Idol AddIdol(Idol idol);
        List<Idol> GetAllIdol();
        Idol UpdateIdol(Idol idolToUpdate);
        Photocard AddPhotocard(Photocard photocard);
        Photocard UpdatePhotocard(Photocard photocardToUpdate);
        Warehouse AddWarehouse(Warehouse warehouse);
        List<Warehouse> GetAllWarehouse();
        Warehouse UpdateWarehouse(Warehouse warehouseToUpdate);
        Inventory AddInventory(Inventory invent);
        Artist GetOneArtistById(int id);
        Album GetOneAlbumById(int id);
        Idol GetOneIdolById(int id);
        Photocard GetOnePhotocardById(int id);
        Warehouse GetOneWarehouseById(int id);
        void RemoveArtist(int id);
        void RemoveAlbum(int id);
        void RemoveIdol(int id);
        void RemovePhotocard(int id);
        void RemoveWarehouse(int id);
        Inventory GetOneInventoryById(int id);
        void RemoveInventory(int id);
    }
}