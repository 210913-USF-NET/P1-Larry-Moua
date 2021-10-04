using System;
using Models;
using RBBL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class CustomerMenu : IMenu
    {
        private IBL _bl;
        private CustomerService _customerService;

        public CustomerMenu(IBL bl, CustomerService customerService)
        {
            _bl = bl;
            _customerService = customerService;
        }

        public void Start()
        {
            if (CustomerLogin() == true)
            {
                CustomerMainMenu();
            }
        }

        public bool CustomerLogin()
        {
            bool exit = false;
            string input2 = "";
            bool success = false;
            
            do
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Please log in with your email address.");

                input2 = Console.ReadLine();

                Console.WriteLine("--------------------");
                Console.WriteLine("Loading...");
                Console.WriteLine("--------------------");

                List<Customer> allCustom = _bl.GetAllCustomers();
                foreach (Customer custom in allCustom)
                {
                    if (input2 == custom.EmailLogin())
                    {
                        DisplayCustomer.Name = custom.Name;
                        DisplayCustomer.CustomerId = custom.Id;
                        DisplayCustomer.Warehouse = "WarehouseUS";
                        DisplayCustomer.WarehouseId = 1;
                        DisplayCustomer.Email = input2;
                        Console.WriteLine($"Log in successful! Welcome back {DisplayCustomer.Name}!");
                        success = true;
                        exit = true;
                    }
                }

                if (exit == false)
                {
                    Console.WriteLine("Email does not match our records. Please try again or sign up for an account.");
                    exit = true;
                    break;
                }

            } while (!exit);

            return success;
        }

        public void CustomerMainMenu()
        {
            bool exit = false;
            string input = "";

            do{

            Console.WriteLine("--------------------");
            Console.WriteLine($"Welcome {DisplayCustomer.Name}!");
            Console.WriteLine($"You are currently at {DisplayCustomer.Warehouse}");
            Console.WriteLine("--------------------");
            Console.WriteLine("Please select an option.");
            Console.WriteLine("[0] Change Warehouse");
            Console.WriteLine("[1] Browse Catalog");
            Console.WriteLine("[2] Change Profile Name");
            Console.WriteLine("[3] View Cart");
            Console.WriteLine("[4] View Order History");
            Console.WriteLine("[x] Sign Out");

            input = Console.ReadLine();

                switch(input)
                {
                    case "0":
                        ChangeWarehouse();
                        break;

                    case "1":
                        BrowseWarehouse();
                        break;

                    case "2":
                        ChangeName();
                        break;

                    case "3":
                        ViewCart();
                        break;

                    case "4":
                        ViewOrderHistory();
                        break;

                    case "x":
                        DisplayCart.cart.Clear();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Please enter a proper command.");
                        break;
                }

            } while (!exit);
        }

        public void ChangeName()
        {
            Console.WriteLine($"Your name is {DisplayCustomer.Name}. Do you wish to change it?");
            string confirmInput = Console.ReadLine();
            switch(confirmInput)
            {
                case "y":
                    Console.WriteLine("Please input your new name.");
                    string input = Console.ReadLine();
                    Console.WriteLine($"Your new name is {input}!");

                    List<Customer> allCustom = _bl.GetAllCustomers();
                    foreach (Customer custom in allCustom)
                    {
                        if (DisplayCustomer.Email == custom.Email)
                        {
                            custom.Name = input;
                            DisplayCustomer.Name = input;
                            Console.WriteLine(custom.Name);
                            _bl.UpdateCustomer(custom, input);
                        }
                    }
                    break;

                case "n":
                    break;

                default:
                    Console.WriteLine("Please enter [y] or [n] and try again.");
                    break;
            }
        }

        public void ChangeWarehouse()
        {
            bool exit = false;
            string input = "";
            do {
                Console.WriteLine($"You are currently at {DisplayCustomer.Warehouse}.");
                Console.WriteLine("Please select the warehouse you wish to use.");
                Console.WriteLine("[0] WarehouseUS");
                Console.WriteLine("[1] WarehouseDE");
                Console.WriteLine("[2] WarehouseKR");
                Console.WriteLine("[x] Cancel");
                input = Console.ReadLine();

                switch(input)
                {
                    case "0":
                        DisplayCustomer.Warehouse = "WarehouseUS";
                        DisplayCustomer.WarehouseId = 1;
                        exit = true;
                        break;

                    case "1":
                        DisplayCustomer.Warehouse = "WarehouseDE";
                        DisplayCustomer.WarehouseId = 2;
                        exit = true;
                        break;
                    
                    case "2":
                        DisplayCustomer.Warehouse = "WarehouseKR";
                        DisplayCustomer.WarehouseId = 3;
                        exit = true;
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

        public void BrowseWarehouse()
        {
            int id = 0;
            if (DisplayCustomer.Warehouse == "WarehouseUS")
            {
                id = 1;
            } else if (DisplayCustomer.Warehouse == "WarehouseDE")
            {
                id = 2;
            } else if (DisplayCustomer.Warehouse == "WarehouseKR")
            {
                id = 3;
            }

            string setName = "";
            decimal setPrice = 0;

            Console.WriteLine($"-----INVENTORY AT {DisplayCustomer.Warehouse}-----");
            List<Product> tempCatalog = new List<Product>();
            List<Photocard> allPhoto = _bl.GetAllPhotocard();
            List<Inventory> allInvent = _bl.GetAllInventory();
                foreach (Inventory invent in allInvent)
                {
                    if (id == invent.WarehouseId && invent.Stock != 0)
                    {
                        foreach (Photocard photo in allPhoto)
                        {
                            if (invent.PhotocardId == photo.Id)
                            {
                                setName = photo.SetId;
                                setPrice = photo.Price;
                            }
                        }
                        tempCatalog.Add(new Product(DisplayCustomer.WarehouseId, invent.PhotocardId, setName, setPrice));
                    }
                }

            Product selectedInventory = _customerService.SelectAPhoto("Pick a photo to add to cart or type [x] to cancel.", tempCatalog);

            if (selectedInventory != null)
            {
                DisplayCart.cart.Add(selectedInventory);
                Console.WriteLine(DisplayCart.cart[0]);
            } else
            {
                Console.WriteLine("Canceling selection...");
            }

        }

        public void ViewCart()
        {
            string input = "";
            bool exit = false;

            if (DisplayCart.cart.Count == 0)
            {
                Console.WriteLine("Your shopping cart is empty!");
                exit = true;
            } else
            {
                do{
                    decimal total = 0;
                    Console.WriteLine("----------");
                    Console.WriteLine("SHOPPING CART ITEMS");
                    for (int i = 0; i < DisplayCart.cart.Count; i++)
                    {
                        Console.WriteLine(DisplayCart.cart[i]);
                    }
                    Console.WriteLine("----------");
                    Console.WriteLine("Please select an option.");
                    Console.WriteLine("[0] Checkout");
                    Console.WriteLine("[1] Remove From Cart");
                    Console.WriteLine("[x] Cancel");

                    input = Console.ReadLine();

                    switch(input){
                        case "0":
                            
                            total = DisplayCart.cart.Count *5;
                            Console.WriteLine("----------");
                            Console.WriteLine($"Your total is {total}.");
                            Console.WriteLine("Do you wish to check out? [y] or [n]");
                            string input2 = Console.ReadLine();
                                switch(input2)
                                {
                                    case "y":
                                        List<Inventory> allInvent = _bl.GetAllInventory();
                                        for (int i = 0; i < DisplayCart.cart.Count; i++)
                                        {
                                            foreach (Inventory invent in allInvent)
                                            {
                                                if (DisplayCart.cart[i].ReturnWarehouseId() == invent.WarehouseId && DisplayCart.cart[i].ReturnPhotoId() == invent.PhotocardId)
                                                {
                                                    _bl.UpdateInventory(invent, DisplayCart.cart[i].ReturnWarehouseId(), DisplayCart.cart[i].ReturnPhotoId());
                                                }
                                            }

                                            Order newOrd = new Order();
                                            _bl.AddOrder(newOrd, DisplayCustomer.CustomerId, DisplayCart.cart[i].ReturnWarehouseId(), DisplayCart.cart[i].ReturnPhotoId());
                                        }
                                        Console.WriteLine("Checkout successful.");
                                        DisplayCart.cart.Clear();
                                        exit = true;
                                        break;

                                    case "n":
                                        Console.WriteLine("Canceling checkout request...");
                                        exit = true;
                                        break;

                                    default:
                                        Console.WriteLine("Please enter a proper command.");
                                        break;
                                }
                            break;

                        case "1":
                            break;

                        case "debug":
                            for (int i = 0; i < DisplayCart.cart.Count; i++)
                            {
                                Console.WriteLine($"WarehouseId: {DisplayCart.cart[i].ReturnWarehouseId()} PhotocardId:{DisplayCart.cart[i].ReturnPhotoId()}");
                            }
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
        }

        public void ViewOrderHistory()
        {
            List<Order> allOrd = _bl.GetAllOrders();
            foreach (Order ord in allOrd)
            {
                if (DisplayCustomer.CustomerId == ord.CustomerId)
                {
                    Console.WriteLine(ord.ToString());
                }
            }
        }
    }
}