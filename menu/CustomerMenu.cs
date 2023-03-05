using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.implementations;
using FarmProduceManagementApp_File.interfaces;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.menu
{
    public class CustomerMenu
    {
        IProduceManager produceManager = new ProduceManager();
        IOrderManager orderManager = new OrderManager();
        ICustomerManager customerManager = new CustomerManager();


        public void RealCustomerMenu()
        {
            var mainMenu = new MainMenu();
            Console.WriteLine();
            Console.WriteLine("====Customer Menu====");
            Console.WriteLine("Enter 1 to view all produce\nEnter 2 to make order\nEnter 3 to fund wallet\nEnter 4 to check wallet balance\nEnter 5 to update an email\nEnter 0 to go back");
            int option = int.Parse(Console.ReadLine());


            if (option == 0)
            {
                mainMenu.RealMenu();
            }
            else if (option == 1)
            {
                produceManager.GetAllProduces();
            }
            else if (option == 2)
            {
                MakeOrderMenu();
            }
            else if (option == 3)
            {
                FundWallet();
            }
            else if (option == 4)
            {
                CheckWalletBalance();
            }
            else if (option == 5)
            {
                UpdateCustomer();
            }
            else
            {
                Console.WriteLine("Wrong input");
            }

            RealCustomerMenu();
        }

        public void SearchCustomerByEmailMenu()
        {
            Console.WriteLine("Enter the email ");
            string email = Console.ReadLine();
            customerManager.SearchCustomerByEmail(email);
        }
        public void FundWallet()
        {
            // Console.WriteLine("Enter the email ");
            // string email = Console.ReadLine();
            // Console.WriteLine("Enter the password ");
            // int passwd = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount to deposit ");
            double amount = double.Parse(Console.ReadLine());
            var customer = customerManager.SearchCustomerByEmailAndPassWord(MainMenu._currentUser.Email, MainMenu._currentUser.Pin);


            if (customer == null)
            {
                Console.WriteLine("You don't have wallet!");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Invalid amount!");

            }
            else
            {
                customer.Wallet += amount;
            }
            customerManager.RefreshFile();
            Console.WriteLine($"Your balance is #{customer.Wallet}");
        }

        public void MakeOrderMenu()
        {
            // Console.Write("Enter your email address: ");
            //string email = Console.ReadLine();


            bool flag = true;
            double totalPrice = 0;
            Dictionary<string, int> produces = new Dictionary<string, int>();
            var enums = Enum.GetValues(typeof(ProduceCategory));
            while (flag)
            {
                Console.WriteLine("Choose from the following categories");
                foreach (var item in enums)
                {
                    Console.WriteLine("Enter {0} for {1}", (int)item, item.ToString());
                }
                int choice = int.Parse(Console.ReadLine());
                foreach (var item in ProduceManager.listOfProduces)
                {
                    if (choice == (int)item.Category)
                    {
                        Console.WriteLine($"Enter {item.Id} to buy {item.ProduceName}");
                    }
                }
                int option = 0;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input");
                    for (; ; )
                    {
                        foreach (var item in ProduceManager.listOfProduces)
                        {
                            if (choice == (int)item.Category)
                            {
                                Console.WriteLine($"Enter {item.Id} to buy {item.ProduceName}");
                            }
                        }
                        if (int.TryParse(Console.ReadLine(), out option))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }

                    }
                }

                Console.WriteLine($"Enter the quantity : ");
                double quantity = double.Parse(Console.ReadLine());


                var produce = produceManager.GetProduceById(option, choice, quantity);
                var customer = customerManager.SearchCustomerByEmail(MainMenu._currentUser.Email);
                if (produce == null)
                {
                    Console.WriteLine("Quantity requested is more than the stock");
                }
                else if (customer.Wallet < (quantity * produce.Price))
                {
                    Console.WriteLine("You don't have enough amount in your wallet!");
                    break;
                }
                else
                {
                    produces.Add(produce.ProduceName, (int)quantity);
                    customer.Wallet -= (produce.Price * quantity);
                    totalPrice += (produce.Price * quantity);

                    produce.Quantity -= quantity;
                    if (produce.Quantity == 0)
                    {
                        ProduceManager.listOfProduces.Remove(produce);
                    }
                    var id = Transaction.Transactions.Count() == 0 ? 1 : Transaction.Transactions.Count() + 1;
                    Transaction.Transactions.Add(new Transaction(id, produce.Id, produce.Category, produce.ProduceName, MainMenu._currentUser.Email, quantity));
                    Console.WriteLine("Your order is successful");
                }

                Console.WriteLine("Do you want to buy another produce(yes/no): ");
                string opt = Console.ReadLine();
                if (opt.ToLower() == "no")
                {
                    Console.WriteLine($"Your order is successful and the total price is {totalPrice}");
                    flag = false;
                }
            }

            orderManager.MakeOrder(MainMenu._currentUser.Email, totalPrice, produces);

            RealCustomerMenu();

        }

        public void CheckWalletBalance()
        {
            Console.WriteLine();
            // Console.WriteLine("Enter your email");
            // string email = Console.ReadLine();

            // Console.WriteLine("Enter your password");
            // int passwd = int.Parse(Console.ReadLine());

            var customer = customerManager.SearchCustomerByEmailAndPassWord(MainMenu._currentUser.Email, MainMenu._currentUser.Pin);
            if (customer != null)
            {
                Console.WriteLine($"Your wallet balance is {customer.Wallet}");
            }

        }

        public void UpdateCustomer()
        {
            Console.Write("Enter your new email: ");
            string newEmail = Console.ReadLine();
            var customerOutcome = customerManager.Update(newEmail);
            if (customerOutcome)
            {
                Console.WriteLine("Email update is successful");
            }
            else
            {
                Console.WriteLine("Sorry, there is no customer with the email");
            }
        }

        public void DeleteCustomer()
        {
            Console.Write("Enter the email of the customer: ");
            string email = Console.ReadLine();
            var isSucessful = customerManager.Delete(email);
            if (isSucessful)
            {
                Console.WriteLine("Customer deleted successfully");
            }
            else
            {
                Console.WriteLine("The email of the customer is not found");
            }
        }
    }
}