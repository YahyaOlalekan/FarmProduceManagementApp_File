using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.implementations;
using FarmProduceManagementApp_File.interfaces;

namespace FarmProduceManagementApp_File.menu
{
    public class OrderMenu
    {
         IOrderManager orderManager = new OrderManager();
       IProduceManager produceManager = new ProduceManager();
       CustomerMenu customerMenu = new CustomerMenu();
       MainMenu mainMenu = new MainMenu();

        public void RealOrderMenu()
        {
           
            Console.WriteLine("Enter ");
            string email = Console.ReadLine();
            
        }

        public void SearchOrderByRefNumberMenu()
        {
            Console.WriteLine("Enter the reference number ");
            string refNumber = Console.ReadLine();
            orderManager. SearchOrderByRefNumber(refNumber);
        }

       

    }
}