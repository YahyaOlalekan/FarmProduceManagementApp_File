using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.interfaces
{
    public interface IManagerManager
    {
        public Manager SearchManagerById(int id);
        public Manager SearchManagerByStaffRegNo(string staffRegNo);
        public void GetAllmanagers();
        public void RegisterManager(string name, string email, string address, string phoneNumber, int pin, Gender gender);
        public bool Update(string email);
        public bool Delete(string email);
        public bool CheckIfExists(string email);
    }
}