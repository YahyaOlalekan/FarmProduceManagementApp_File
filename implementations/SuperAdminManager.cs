using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.interfaces;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.implementations
{
    public class SuperAdminManager : ISuperAdminManager
    {
        List<SuperAdmin> listOfSuperAdmin = new List<SuperAdmin>();
        string file = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files\superAdmin.txt";
        public SuperAdminManager()
        {
            ReadSuperAdminFromFile();
            
        }

        public void ReadSuperAdminFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var superAdmin = File.ReadAllLines(file);
                    if(superAdmin.Length > 0)
                    {
                        foreach (var item in superAdmin)
                        {
                        listOfSuperAdmin.Add(SuperAdmin.ToSuperAdmin(item));
                        }
                    }
                    
                }
                else
                {
                    string path = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files";
                    Directory.CreateDirectory(path);
                    string fileName = "superAdmin.txt";
                    string fullPath = Path.Combine(path, fileName);
                    File.Create(fullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteSuperAdminToFile(SuperAdmin superAdmin)
        {
            try
            {
                using (var write = new StreamWriter(file, true))
                {
                    write.WriteLine(superAdmin.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public SuperAdmin SearchSuperAdminByEmailAndPassWord(string email, int passwd)
        {
            foreach (var superAdmin in listOfSuperAdmin)
            {
                if (superAdmin.Email == email && superAdmin.Pin == passwd && superAdmin.IsDeleted == false)
                {
                    return superAdmin;
                }
            }
            return null;
        }


        
       
    }
}