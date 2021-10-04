using System;
using Models;
using RBBL;
using System.Collections.Generic;

namespace UI
{
    public class AdminMenu : IMenu
    {
        private IBL _bl;
        private AdminService _adminService;

        public AdminMenu(IBL bl, AdminService adminService)
        {
            _bl = bl;
            _adminService = adminService;
        }

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Please select an option.");
                Console.WriteLine("[0] View Inventory");
                Console.WriteLine("[1] View All Customers");
                Console.WriteLine("[2] View All Orders");
                Console.WriteLine("[x] Sign Out");

                switch (Console.ReadLine())
                {
                    case "0":
                        ViewCatalog();
                        break;

                    case "1":
                        ViewAllCustomers();
                        break;

                    case "2":
                        ViewAllOrders();
                        break;
                    
                    case "x":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Please enter a proper command.");
                        break;
                }

            } while (!exit);
        }

        public void ViewAllCustomers()
        {
            List<Customer> allCustom = _bl.GetAllCustomers();
            foreach (Customer custom in allCustom)
            {
                Console.WriteLine(custom.ToString());
            }
        }

        public void ViewCatalog()
        {
            string input = "";
            string stockInput = "";
            int stockInt = 0;
            List<Inventory> allInvent = _bl.GetAllInventory();
            Inventory selectedInventory = _adminService.SelectInventory("Select an item you wish to restock or type [x] to cancel.", allInvent);

            if (selectedInventory != null)
            {
                Console.WriteLine($"You have selected {selectedInventory}");
                Console.WriteLine($"Please confirm your selection. [y] or [n]");
                input = Console.ReadLine();
                switch(input)
                {
                    case "y":
                        Console.WriteLine("Please modify the stock available for this product.");
                        stockInput = Console.ReadLine();
                        Console.WriteLine($"You are changing this product to have {stockInput} available. Is this correct? [y] or [n]");
                        string input2 = Console.ReadLine();
                        switch(input2)
                        {
                            case "y":
                                Int32.TryParse(stockInput, out stockInt);

                                // run code to change the stock
                                _bl.StockInventory(selectedInventory, stockInt);
                                Console.WriteLine("Change successful!");
                                break;

                            case "n":
                                break;

                            default:
                                Console.WriteLine("Please enter a proper command and try again.");
                                break;
                        }
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine($"Please enter a proper command and try again.");
                        break;
                }
            } else
            {
                Console.WriteLine("Canceling selection...");
            }
        }

        public void ViewAllOrders()
        {
            List<Order> allOrd = _bl.GetAllOrders();
            foreach (Order ord in allOrd)
            {
                Console.WriteLine(ord.ToString());
            }
        }
    }
}