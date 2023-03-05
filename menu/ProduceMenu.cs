using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.implementations;
using FarmProduceManagementApp_File.interfaces;

namespace FarmProduceManagementApp_File.menu
{
    public class ProduceMenu
    {
         IProduceManager produceManager = new ProduceManager();
         public void GetProduceByProduceNameMenu()
        {
            Console.WriteLine("Enter the produceName ");
            string produceName = Console.ReadLine();
            produceManager.GetProduceByProduceName(produceName);
        }
    }
}