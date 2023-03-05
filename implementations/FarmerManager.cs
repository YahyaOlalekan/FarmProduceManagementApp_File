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
    public class FarmerManager : IFarmerManager
    {
       public static List<Farmer> listOfFarmers = new List<Farmer>();
        string file = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files\farmer.txt";
        public FarmerManager()
        {
            if (listOfFarmers.Count == 0)
            {
                ReadFarmerFromFile();
            }

        }

        private void ReadFarmerFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var farmer = File.ReadAllLines(file);
                    if (farmer.Length > 0)
                    {
                        foreach (var item in farmer)
                        {
                            listOfFarmers.Add(Farmer.ToFarmer(item));
                        }
                    }

                }
                else
                {
                    string path = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files";
                    Directory.CreateDirectory(path);
                    string fileName = "farmer.txt";
                    string fullPath = Path.Combine(path, fileName);
                    File.Create(fullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteFarmerToFile(Farmer farmer)
        {
            try
            {
                using (var write = new StreamWriter(file, true))
                {
                    write.WriteLine(farmer.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void RefreshFile()
        {
            try
            {
                using (var write = new StreamWriter(file, false))
                {
                    foreach (var farmer in listOfFarmers)
                    {
                        write.WriteLine(farmer.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string GetFarmerRegNumber()
        {
            return "CLH/FAR/00" + (listOfFarmers.Count + 1);
        }

        public void RegisterFarmer(string name, string email, int pin, Gender gender, string address, string phoneNumber)
        {
            var farmer = new Farmer(listOfFarmers.Count + 1, GenerateFarmerRegNo(), 0, "Farmer", FarmerRegStatus.Pending, name, email, address, phoneNumber, pin, gender);
            listOfFarmers.Add(farmer);
            WriteFarmerToFile(farmer);

            Console.WriteLine($"Dear {name}, you have been sucessfully registered, your registration number is {farmer.FarmerRegNo} and your wallet balance is {farmer.Wallet}");
        }

        private string GenerateFarmerRegNo()
        {
            return "CLH/FAR/00" + (listOfFarmers.Count + 1).ToString();
        }



        public Farmer SearchFarmerById(int id)
        {
            foreach (var farmer in listOfFarmers)
            {
                if (farmer.Id == id && farmer.IsDeleted == false)
                {
                    return farmer;
                }
            }
            return null;
        }

        public Farmer SearchFarmerByRegNo(string regNo)
        {
            foreach (var farmer in listOfFarmers)
            {
                if (farmer.FarmerRegNo == regNo && farmer.IsDeleted == false)
                {
                    return farmer;
                }
            }
            return null;
        }



        public void UpdateFarmerStatusMenu()
        {
            throw new NotImplementedException();
        }



        public Farmer SearchFarmerByEmailAndPassWord(string email, int passwd)
        {
            foreach (var farmer in listOfFarmers)
            {
                if (farmer.Email == email && farmer.Pin == passwd && farmer.IsDeleted == false)
                {
                    return farmer;
                }
            }
            return null;
        }

        public Farmer SearchFarmerByEmail(string email)
        {

            foreach (var farmer in listOfFarmers)
            {
                if (farmer.Email == email && farmer.IsDeleted == false)
                {
                    return farmer;
                }
            }
            return null;
        }

        public bool Update(string newEmail)
        {
            var farmer = SearchFarmerByEmail(MainMenu._currentUser.Email);
            if (farmer == null)
            {
                return false;
            }
            farmer.Email = newEmail;
            RefreshFile();
            MainMenu._currentUser.Email = newEmail;
            return true;
        }

        

        public bool Delete(string email)
        {
             var farmer = SearchFarmerByEmail(email);
            if(farmer == null)
            {
                return false;
            }
            farmer.IsDeleted = true;
            RefreshFile();
            return true;
        }

        public bool CheckIfExists(string email)
        {
             foreach(var farmer in listOfFarmers)
            {
                if(farmer.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}