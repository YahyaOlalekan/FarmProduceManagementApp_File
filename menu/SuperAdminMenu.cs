using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.implementations;
using FarmProduceManagementApp_File.interfaces;

namespace FarmProduceManagementApp_File.menu
{
    public class SuperAdminMenu
    {
         IManagerManager managerManager = new ManagerManager();
       IFarmerManager farmerManager = new FarmerManager();
        ManagerMenu managerMenu = new ManagerMenu();

       
       
        public void RealSuperAdminMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Enter 1 to register manager\nEnter 2 to search for the manager by staff registration number\nEnter 3 to view all the managers\nEnter 4 to delete a manager\nEnter 5 t0 delete a farmer\nEnter 0 t0 go back");
            int opt = int.Parse(Console.ReadLine());

            if(opt == 1)
            {
                managerMenu.ManagerSignUpMenu();
            }
            else if(opt == 2)
            {
                managerMenu.SearchManagerByStaffRegNoMenu();
            }
            else if(opt == 3)
            {
                managerManager.GetAllmanagers();
            }
            else if(opt == 4)
            {
                managerMenu.DeleteManager();
            }
            else if(opt == 5)
            {
                var farmerMenu = new FarmerMenu();
                farmerMenu.DeleteFarmer();
            }
            else if(opt == 0)
            {
               var mainMenu = new MainMenu();
               mainMenu.RealMenu();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            RealSuperAdminMenu();
        }
    }
}