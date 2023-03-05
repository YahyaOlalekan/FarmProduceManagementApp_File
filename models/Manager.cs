using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class Manager : User
    {
        public string StaffRegNo { get; set; }
        public double Wallet { get; set; }
        public string Role { get; set; }

        public Manager(int id, string staffRegNo, string role, double wallet, string name, string email, string address, string phoneNumber, int pin, Gender gender) : base(id, name, email, address, phoneNumber, pin, gender)
        {
            StaffRegNo = staffRegNo;
            Wallet = wallet;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Id}\t{StaffRegNo}\t{Role}\t{Wallet}\t{Name}\t{Email}\t{Address}\t{PhoneNumber}\t{Pin}\t{Gender}\t{IsDeleted}";
        }

        public static Manager ToManager(string manager)
        {
            var managerStr = manager.Split('\t');
            int id = int.Parse(managerStr[0]);
            string staffRegNo = managerStr[1];
            string role = managerStr[2];
            double wallet = double.Parse(managerStr[3]);
            string name = managerStr[4];
            string email = managerStr[5];
            string address = managerStr[6];
            string phoneNumber = managerStr[7];
            int pin = int.Parse(managerStr[8]);
            var gender = Enum.Parse<Gender>(managerStr[9]);
            bool isDeleted = bool.Parse(managerStr[10]);

            var managerObject = new Manager(id, staffRegNo, role, wallet, name, email, address, phoneNumber, pin, gender);
            managerObject.IsDeleted = isDeleted;
            return managerObject;

        }

    }
}