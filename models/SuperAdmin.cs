using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class SuperAdmin : User
    {
        public string StaffRegNo { get; set; }
        public string Role { get; set; }

        public SuperAdmin(int id, string staffRegNo, string role, string name, string email, string address, string phoneNumber, int pin, Gender gender) : base(id, name, email, address, phoneNumber, pin, gender)
        {
            StaffRegNo = staffRegNo;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Id}%%%%{StaffRegNo}%%%%{Role}%%%%{Name}%%%%{Email}%%%%{Address}%%%%{PhoneNumber}%%%%{Pin}%%%%{Gender}%%%%{IsDeleted}";
        }

        public static SuperAdmin ToSuperAdmin(string superAdmin)
        {
            var superAdminStr = superAdmin.Split("%%%%");
            int id = int.Parse(superAdminStr[0]);
            string staffRegNo = superAdminStr[1];
            string role = superAdminStr[2];
            string name = superAdminStr[3];
            string email = superAdminStr[4];
            string address = superAdminStr[5];
            string phoneNumber = superAdminStr[6];
            int pin = int.Parse(superAdminStr[7]);
            Gender gender = (Gender)Enum.Parse(typeof(Gender), superAdminStr[8]);
            bool isDeleted = bool.Parse(superAdminStr[9]);

            var superAdminObject = new SuperAdmin(id, staffRegNo, role, name, email, address, phoneNumber, pin, gender);
            superAdminObject.IsDeleted = isDeleted;
            return superAdminObject;

        }

    }
}