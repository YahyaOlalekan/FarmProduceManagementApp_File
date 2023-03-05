using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.interfaces
{
    public interface ISuperAdminManager
    {
       // public void UpdateProfile(string name, string email, Gender gender, string address, string phoneNumber);
        //public SuperAdmin SearchByEmail(string email);
        public SuperAdmin SearchSuperAdminByEmailAndPassWord(string email, int passwd);
    }
}