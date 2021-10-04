using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Customer
    {
        public Customer() {}

        public Customer(int id, string name, string email, string address, int points)
        {

        }

        public int Id { get; set; }

        private string _name;

        public string Name
        {
            get { return _name;}
            set
            {
                Regex pattern = new Regex("^[a-zA-Z ]+$");

                if(value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Customer name can't be empty");
                    Log.Warning(e.Message);
                    throw e;
                }
                else if(!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Customer name can only have alphabetical characters and spaces.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private string _email;

        public string Email {
            get{ return _email;}
            set
            {
                Regex pattern = new Regex("^[a-zA-Z0-9@._]");

                if(value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Email can't be empty");
                    Log.Warning(e.Message);
                    throw e;
                }
                else if(!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Email can only have alphanumerical characters, @, and . with no spaces.");
                }
                else
                {
                    _email = value;
                }
            }
        }
        public string Address { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id} Name: {this.Name}, Email: {this.Email}, Address: {this.Address}, Points: {this.Points}";
        }

        public string EmailLogin()
        {
            return $"{this.Email}";
        }

    }
}
