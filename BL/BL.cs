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

        public Customer UpdateCustomer(Customer customToUpdate)
        {
            return _repo.UpdateCustomer(customToUpdate);
        }

        public Artist AddArtist(Artist art)
        {
            return _repo.AddArtist(art);
        }

        public List<Artist> GetAllArtist()
        {
            return _repo.GetAllArtist();
        }

        public Artist UpdateArtist(Artist artistToUpdate)
        {
            return _repo.UpdateArtist(artistToUpdate);
        }
        public List<Photocard> GetAllPhotocard()
        {
            return _repo.GetAllPhotocard();
        }

        public Inventory UpdateInventory(Inventory inventoryToUpdate)
        {
            return _repo.UpdateInventory(inventoryToUpdate);
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

        public Customer GetOneCustomerById(int id)
        {
            return _repo.GetOneCustomerById(id);
        }

        public Customer GetOneCustomerByEmail(string email)
        {
            return _repo.GetOneCustomerByEmail(email);
        }

        public Album AddAlbum(Album album)
        {
            return _repo.AddAlbum(album);
        }

        public List<Album> GetAllAlbum()
        {
            return _repo.GetAllAlbum();
        }

        public Album UpdateAlbum(Album albumToUpdate)
        {
            return _repo.UpdateAlbum(albumToUpdate);
        }

        public Idol AddIdol(Idol idol)
        {
            return _repo.AddIdol(idol);
        }

        public List<Idol> GetAllIdol()
        {
            return _repo.GetAllIdol();
        }

        public Idol UpdateIdol(Idol idolToUpdate)
        {
            return _repo.UpdateIdol(idolToUpdate);
        }

        public Photocard AddPhotocard(Photocard photocard)
        {
            return _repo.AddPhotocard(photocard);
        }

        public Photocard UpdatePhotocard(Photocard photocardToUpdate)
        {
            return _repo.UpdatePhotocard(photocardToUpdate);
        }

        public Warehouse AddWarehouse(Warehouse warehouse)
        {
            return _repo.AddWarehouse(warehouse);
        }

        public List<Warehouse> GetAllWarehouse()
        {
            return _repo.GetAllWarehouse();
        }

        public Warehouse UpdateWarehouse(Warehouse warehouseToUpdate)
        {
            return _repo.UpdateWarehouse(warehouseToUpdate);
        }

        public Inventory AddInventory(Inventory invent)
        {
            return _repo.AddInventory(invent);
        }

        public Artist GetOneArtistById(int id)
        {
            return _repo.GetOneArtistById(id);
        }
        public Album GetOneAlbumById(int id)
        {
            return _repo.GetOneAlbumById(id);
        }
        public Idol GetOneIdolById(int id)
        {
            return _repo.GetOneIdolById(id);
        }

        public Photocard GetOnePhotocardById(int id)
        {
            return _repo.GetOnePhotocardById(id);
        }

        public Warehouse GetOneWarehouseById(int id)
        {
            return _repo.GetOneWarehouseById(id);
        }

        public void RemoveArtist(int id)
        {
            _repo.RemoveArtist(id);
        }

        public void RemoveAlbum(int id)
        {
            _repo.RemoveAlbum(id);
        }

        public void RemoveIdol(int id)
        {
            _repo.RemoveIdol(id);
        }
        public void RemovePhotocard(int id)
        {
            _repo.RemovePhotocard(id);
        }
        public void RemoveWarehouse(int id)
        {
            _repo.RemoveWarehouse(id);
        }

        public Inventory GetOneInventoryById(int id)
        {
            return _repo.GetOneInventoryById(id);
        }

        public void RemoveInventory(int id)
        {
            _repo.RemoveInventory(id);
        }
    }
}
