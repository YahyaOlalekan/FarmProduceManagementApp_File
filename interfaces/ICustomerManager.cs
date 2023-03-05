using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.interfaces
{
    public interface ICustomerManager
    {
         public void RegisterCustomer(string name, string email, int pin, Gender gender, string address, string phoneNumber);
        public Customer SearchCustomerById(int id);
        public Customer SearchCustomerByEmailAndPassWord(string email , int passwd);
        public Customer SearchCustomerByRegNo(string regNo);
        public Customer SearchCustomerByEmail(string email);
        public void GetAllCustomers();
        public bool Update(string email);
        public bool Delete(string email);
        public bool CheckIfExists(string email);
        public void RefreshFile();
    }
}