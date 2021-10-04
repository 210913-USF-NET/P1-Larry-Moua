using System;
using Models;
using RBBL;
using DL;
using System.Collections.Generic;

namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("Welcome to Kpop Snapshot!");
                Console.WriteLine("Please choose an option or type 'x' to exit.");
                Console.WriteLine("[0] New Account");
                Console.WriteLine("[1] Log In");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {


                    case "admin":
                        Console.WriteLine("Welcome Admin!");
                        MenuFactory.GetMenu("admin").Start();
                    break;

                    case "0":
                        Console.WriteLine("Creating new account!");
                        MenuFactory.GetMenu("new-customer").Start();
                    break;
                    
                    case "1":
                        MenuFactory.GetMenu("customer").Start();
                    break;

                    case "x":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                    break;

                    default:
                        Console.WriteLine("Please enter a proper command.");
                        break;
                }

            } while (!exit);

        }
    }
}