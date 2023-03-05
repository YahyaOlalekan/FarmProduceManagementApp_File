using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.implementations;
using FarmProduceManagementApp_File.interfaces;

namespace FarmProduceManagementApp_File.menu
{
    public class ManagerMenu
    {
        IManagerManager managerManager = new ManagerManager();
        IOrderManager orderManager = new OrderManager();
        IProduceManager produceManager = new ProduceManager();
        ICustomerManager customerManager = new CustomerManager();
        ProduceMenu produceMenu = new ProduceMenu();
        CustomerMenu customerMenu = new CustomerMenu();
        FarmerMenu farmerMenu = new FarmerMenu();

        public void RealManagerMenu()
        {
            Console.WriteLine("Enter 1 to view all orders\nEnter 2 to get all produces\nEnter 3 to search customer by email\nEnter 4 to view all customers\nEnter 5 to delete a customer\nEnter 6 to delete a farmer\nEnter 0 to go back");
            int opt = int.Parse(Console.ReadLine());


            if (opt == 1)
            {
                orderManager.GetAllOrders();
            }

            else if (opt == 2)
            {
                produceManager.GetAllProduces();
            }
            else if (opt == 3)
            {
                customerMenu.SearchCustomerByEmailMenu();
            }
            else if (opt == 4)
            {
                customerManager.GetAllCustomers();
            }
            else if (opt == 5)
            {
                customerMenu.DeleteCustomer();
            }
            else if (opt == 6)
            {
                farmerMenu.DeleteFarmer();
            }
            // if (opt == 1)
            // {
            //     orderManager.SearchOrderByRefNumberMenu();
            // }
            // else if (opt == 3)
            // {
            //     produceManager.GetProduceByProduceNameMenu();
            // }
            else if (opt == 0)
            {
                var mainMenu = new MainMenu();
                mainMenu.RealMenu();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

        }

        public void SearchManagerByStaffRegNoMenu()
        {
            Console.WriteLine("Enter the registration number of the manager ");
            string regNo = Console.ReadLine();
            var manager = managerManager.SearchManagerByStaffRegNo(regNo);
            if (manager == null)
            {
                Console.WriteLine("Not found!");
            }
            else
            {
                Console.WriteLine($" You have searched for {manager.Name}, having an email of {manager.Email}, id number {manager.Id}, pin {manager.Pin}, phone number {manager.PhoneNumber} with an address {manager.Address}");
            }
        }

        public void ManagerSignUpMenu()
        {
            Console.WriteLine("====Registration Of Manager====");
            Console.Write("Enter the following information about the manager: ");
            Console.WriteLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();


            Console.Write("Pin: ");
            int pin = int.Parse(Console.ReadLine());

            Console.Write("Enter 1 for male, 2 for female: ");
            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());

            if (managerManager.CheckIfExists(email))
            {
                Console.WriteLine("The email already exists!");
            }
            else
            {
                managerManager.RegisterManager(name, email, address, phoneNumber, pin, gender);

            }
            Console.WriteLine();
        }


        public void UpdateManager()
        {
            Console.Write("Enter your new email: ");
            string newEmail = Console.ReadLine();
            var managerOutcome = managerManager.Update(newEmail);
            if (managerOutcome)
            {
                Console.WriteLine("Email update is successful");
            }
            else
            {
                Console.WriteLine("Sorry, there is no manager with the email");
            }
        }

        public void DeleteManager()
        {
            Console.Write("Enter the email of the manager: ");
            string email = Console.ReadLine();
            var isSucessful = managerManager.Delete(email);
            if (isSucessful)
            {
                Console.WriteLine("Manager deleted successfully");
            }
            else
            {
                Console.WriteLine("The email of the manager is not found");
            }
        }

    }
}