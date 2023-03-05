using System;
using FarmProduceManagementApp_File.implementations;
using FarmProduceManagementApp_File.menu;

namespace FarmProduceManagementApp_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            mainMenu.RealMenu();
        }
    }
}
