using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class Farmer : User
    {
        public string FarmerRegNo { get; set; }
        public double Wallet{ get; set; }
        public string Role { get; set; }
        public FarmerRegStatus FarmerRegStatus {get; set;}// = default!;

        public Farmer(int id, string farmerRegNo, double wallet, string role, FarmerRegStatus farmerRegStatus, string name, 
        string email, string address, string phoneNumber, int pin, Gender gender) : base(id, name, email, address, phoneNumber, pin, gender)
        {
        
            FarmerRegNo = farmerRegNo;
            Wallet = wallet;
            Role = role;
            FarmerRegStatus = farmerRegStatus;
        }

    
       
        public override string ToString()
        {
            return $"{Id}\t{FarmerRegNo}\t{Wallet}\t{Role}\t{FarmerRegStatus}\t{Name}\t{Email}\t{Address}\t{PhoneNumber}\t{Pin}\t{Gender}\t{IsDeleted}";
        }

        public static Farmer ToFarmer(string farmer)
        {
            var farmerStr = farmer.Split('\t');
            int id = int.Parse(farmerStr[0]);
            string farmerRegNo = farmerStr[1];
            double wallet = double.Parse(farmerStr[2]);
            string role = farmerStr[3];
            FarmerRegStatus farmerRegStatus = Enum.Parse<FarmerRegStatus>(farmerStr[4]);
            string name = farmerStr[5];
            string email = farmerStr[6];
            string address = farmerStr[7];
            string phoneNumber = farmerStr[8];
            int pin = int.Parse(farmerStr[9]);
            Gender gender = Enum.Parse<Gender>(farmerStr[10]);
            bool isDeleted = bool.Parse(farmerStr[11]);

            var farmerObject = new Farmer(id, farmerRegNo, wallet, role, farmerRegStatus, name, email, address, phoneNumber, pin, gender);
            farmerObject.IsDeleted = isDeleted;
            return farmerObject;
        }
    }
}