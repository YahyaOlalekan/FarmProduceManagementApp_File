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
    public class ManagerManager : IManagerManager
    {
       
     public static  List<Manager> listOfManagers = new List<Manager>();
        string file = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files\manager.txt";
        public ManagerManager()
        {
            if(listOfManagers.Count == 0)
            {
                ReadManagerFromFile();
            }
            
        }

        private void ReadManagerFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var manager = File.ReadAllLines(file);
                    if(manager.Length > 0)
                    {
                        foreach (var item in manager)
                        {
                        listOfManagers.Add(Manager.ToManager(item));
                        }
                    }
                    
                }
                else
                {
                    string path = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files";
                    Directory.CreateDirectory(path);
                    string fileName = "manager.txt";
                    string fullPath = Path.Combine(path, fileName);
                    File.Create(fullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteManagerToFile(Manager manager)
        {
            try
            {
                using (var write = new StreamWriter(file, true))
                {
                    write.WriteLine(manager.ToString());
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
                    foreach (var manager in listOfManagers)
                    {
                        write.WriteLine(manager.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        

         private string GenerateManagererRegNo()
        {
            return "CLH/MGR/00"+(listOfManagers.Count + 1).ToString();
        }

       

        public Manager SearchManagerById(int id)
        {
            foreach(var manager in listOfManagers)
            {
                if(manager.Id == id && manager.IsDeleted == false)
                {
                    return manager;
                }
            }
            return null;
        }

        public Manager SearchManagerByStaffRegNo(string staffRegNo)
        {
             foreach(var manager in listOfManagers)
            {
                if(manager.StaffRegNo == staffRegNo && manager.IsDeleted == false)
                {
                    return manager;
                }
            }
            return null;
        }

       

        public void RegisterManager(string name, string email, string address, string phoneNumber, int pin, Gender gender)
        {
            var manager = new Manager(listOfManagers.Count + 1, GenerateManagererRegNo(),  "Manager", 0, name, email, address,phoneNumber, pin, gender);
            listOfManagers.Add(manager);
            WriteManagerToFile(manager);

            Console.WriteLine($"{name} registered successfully, his staff registration number is {manager.StaffRegNo}");
        }

        public void GetAllmanagers()
        {
            foreach(var manager in listOfManagers)
            {
                if(manager.IsDeleted == false)
                
                Console.WriteLine($"{manager.Name}  has a staff registration number {manager.StaffRegNo}");
            }
        }

       
        public Manager SearchManagerByEmail(string email)
        {
            foreach (var manager in listOfManagers)
            {
                if (manager.Email == email && manager.IsDeleted == false)
                {
                    return manager;
                }
            }
            return null;
        }

        public bool Update(string newEmail)
        {
            var manager = SearchManagerByEmail(MainMenu._currentUser.Email);
            if (manager == null)
            {
                return false;
            }
            manager.Email = newEmail;
            RefreshFile();
            return true;
        }

        public bool Delete(string email)
        {
             var manager = SearchManagerByEmail(email);
            if(manager == null)
            {
                return false;
            }
            manager.IsDeleted = true;
            RefreshFile();
            return true;
        }

        public bool CheckIfExists(string email)
        {
            foreach(var manager in listOfManagers)
            {
                if(manager.Email == email)
                {
                    return true;
                }
            } 
            return false;
        }
    }

}