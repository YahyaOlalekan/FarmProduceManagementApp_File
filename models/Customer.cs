using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class Customer : User
    {
        public string CustomerRegNo { get; set; }
        public double Wallet { get; set; }
        public string Role { get; set; }
        


        public Customer(string customerRegNo, double wallet, string role, int id, string name, string email, string address, string phoneNumber, int pin, Gender gender) : base(id, name, email, address, phoneNumber, pin, gender)
        {

            CustomerRegNo = customerRegNo;
            Wallet = wallet;
            Role = role;
            
        }

        public override string ToString()
        {
            return $"{CustomerRegNo}\t{Wallet}\t{Role}\t{Id}\t{Name}\t{Email}\t{Address}\t{PhoneNumber}\t{Pin}\t{Gender}\t{IsDeleted}";
        }

        public static Customer ToCustomer(string customer)
        {
            var customerStr = customer.Split('\t');
            string customerRegNo = customerStr[0];
            double wallet = double.Parse(customerStr[1]);
            string role = customerStr[2];
            int id = int.Parse(customerStr[3]);
            string name = customerStr[4];
            string email = customerStr[5];
            string address = customerStr[6];
            string phoneNumber = customerStr[7];
            int pin = int.Parse(customerStr[8]);
            Gender gender = Enum.Parse<Gender>(customerStr[9]);
            bool isDeleted = bool.Parse(customerStr[10]);

            var customerObject = new Customer(customerRegNo, wallet, role, id,  name, email, address, phoneNumber, pin, gender);
            customerObject.IsDeleted = isDeleted;
            return customerObject;
        }

    }
}