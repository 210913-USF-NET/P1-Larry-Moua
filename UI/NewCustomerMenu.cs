using System;
using Models;
using RBBL;
using System.Collections.Generic;
using Serilog;

namespace UI
{
    public class NewCustomerMenu : IMenu
    {
        private IBL _bl;
        private NewCustomerService _newCustomerService;

        public NewCustomerMenu(IBL bl, NewCustomerService newCustomerService)
        {
            _bl = bl;
            _newCustomerService = newCustomerService;
        }

        public void Start()
        {
            bool exit = false;
            string input = "";
            string newName = "";
            string newEmail = "";
            string newAddress = "";
            do
            {
                userInput:
                Console.WriteLine("--------------------");
                Console.WriteLine("Please enter the following.");
                Console.WriteLine("FULL NAME");
                Console.WriteLine("EMAIL");
                Console.WriteLine("ADDRESS");

                newName = Console.ReadLine();
                newEmail = Console.ReadLine();
                newAddress = Console.ReadLine();

                confirm:
                Console.WriteLine("--------------------");
                Console.WriteLine($"NAME: {newName}");
                Console.WriteLine($"EMAIL: {newEmail}");
                Console.WriteLine($"ADDRESS: {newAddress}");
                Console.WriteLine("Is this correct? [y] to confirm or [n] to reset");

                input = Console.ReadLine();

                switch(input){
                    case "y":
                        List<Customer> allCustom = _bl.GetAllCustomers();
                        foreach (Customer custom in allCustom)
                        {
                            if (newEmail == custom.EmailLogin())
                            {
                                Console.WriteLine($"An account already exists with this email. Please use another email or log in.");
                                exit = true;
                            }
                        }

                        if (exit == false)
                        {
                        Customer newCustom = new Customer();
                        newCustom.Name = newName;
                        newCustom.Email = newEmail;
                        newCustom.Address = newAddress;
                        newCustom.Points = 0;
                        Customer addedCustom = _bl.AddCustomer(newCustom);
                        Console.WriteLine($"You created {addedCustom}");
                        Console.WriteLine("New user created! Please log in with your email address.");
                        Log.Information("New CUSTOMER Created");
                        exit = true;
                        }
                        
                    break;
                    
                    case "n":
                        goto userInput;

                    default:
                        Console.WriteLine("Please enter y or n");
                        goto confirm;
                }
            } while (!exit);
        }
    }
}