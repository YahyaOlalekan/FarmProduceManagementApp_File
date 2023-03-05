using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.interfaces;
using FarmProduceManagementApp_File.menu;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.implementations
{
    public class CustomerManager : ICustomerManager
    {
         static List<Customer> listOfCustomers = new List<Customer>();
        string file = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files\customer.txt";
        public CustomerManager()
        {
            if(listOfCustomers.Count == 0)
            {
                 ReadCustomerFromFile();
            }
           
        }

        private void ReadCustomerFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var customer = File.ReadAllLines(file);
                    if(customer.Length > 0)
                    {
                        foreach (var item in customer)
                        {
                        listOfCustomers.Add(Customer.ToCustomer(item));
                        }
                    }
                    
                }
                else
                {
                    string path = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files";
                    Directory.CreateDirectory(path);
                    string fileName = "customer.txt";
                    string fullPath = Path.Combine(path, fileName);
                    File.Create(fullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteCustomerToFile(Customer customer)
        {
            try
            {
                using (var write = new StreamWriter(file, true))
                {
                    write.WriteLine(customer.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RefreshFile()
        {
            try
            {
                using (var write = new StreamWriter(file, false))
                {
                    foreach(var customer in listOfCustomers)
                    {
                         write.WriteLine(customer.ToString());
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
        public void GetAllCustomers()
        {
            foreach (var customer in listOfCustomers)
            {
               if(!customer.IsDeleted)
                Console.WriteLine($"{customer.Name}\t{customer.CustomerRegNo}\t{customer.Address}\t{customer.PhoneNumber}");
            }
        }

        public void RegisterCustomer(string name, string email, int pin, Gender gender, string address, string phoneNumber)
        {
            var customer = new Customer(GenerateCustomerRegNo(), 0, "Customer" , listOfCustomers.Count + 1, name , email , address , phoneNumber ,  pin , gender);
            listOfCustomers.Add(customer);
            WriteCustomerToFile(customer);

            Console.WriteLine($"Dear {name}, you have been sucessfully registered, your registration number is {customer.CustomerRegNo} and your wallet balance is {customer.Wallet}");
        }

        private string GenerateCustomerRegNo()
        {
            return "CLH/CTM/00" + (listOfCustomers.Count + 1).ToString();
        }

        public Customer SearchCustomerByEmail(string email)
        {
           
            foreach (var customer in listOfCustomers)
            {
                if (customer.Email == email && customer.IsDeleted == false)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer SearchCustomerById(int id)
        {
            foreach (var customer in listOfCustomers)
            {
                if (customer.Id == id && customer.IsDeleted == false)
                {
                    return customer;
                }
            }
            return null;
        }
        
        public bool CheckIfExists(string email)
        {
            foreach(var customer in listOfCustomers)
            {
                if(customer.Email == email)
                {
                    return true;
                }

            }
            return false;
        }
        public Customer SearchCustomerByRegNo(string regNo)
        {
            foreach (var customer in listOfCustomers)
            {
                if (customer.CustomerRegNo == regNo && customer.IsDeleted == false)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer SearchCustomerByEmailAndPassWord(string email, int passwd)
        {
            foreach (var customer in listOfCustomers)
            {
                if (customer.Email == email && customer.Pin == passwd && customer.IsDeleted == false)
                {
                    return customer;
                }
            }
            return null;
        }

        public bool Update(string newEmail)
        {
            var customer = SearchCustomerByEmail(MainMenu._currentUser.Email);
            if(customer == null)
            {
                return false;
            }
            customer.Email = newEmail;
            RefreshFile();
            MainMenu._currentUser.Email = newEmail;
            return true;
        }

        public bool Delete(string email)
        {
            var customer = SearchCustomerByEmail(email);
            if(customer == null)
            {
                return false;
            }
            customer.IsDeleted = true;
            RefreshFile();
            return true;
        }
    }
}