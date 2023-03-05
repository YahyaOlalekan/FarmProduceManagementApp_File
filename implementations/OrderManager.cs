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
    public class OrderManager : IOrderManager
    {
        List<Order> listOfOrders = new List<Order>();

        string file = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files\order.txt";
        public OrderManager()
        {
            if (listOfOrders.Count == 0)
            {
                ReadOrderFromFile();
            }
        }

        private void ReadOrderFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var order = File.ReadAllLines(file);
                    if(order.Length > 0)
                    {
                        foreach (var item in order)
                        {
                        listOfOrders.Add(Order.ToOrder(item));
                        }
                    }
                    
                }
                else
                {
                    string path = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files";
                    Directory.CreateDirectory(path);
                    string fileName = "order.txt";
                    string fullPath = Path.Combine(path, fileName);
                    File.Create(fullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteOrderToFile(Order order)
        {
            try
            {
                using (var write = new StreamWriter(file, true))
                {
                    write.WriteLine(order.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CancelOrderByRefNumber(string refNumber)
        {
            foreach (var order in listOfOrders)
            {
                if (order.RefNumber == refNumber && order.IsDeleted == false)
                {
                    order.Status = DeliveryStatus.Cancel;
                }
            }
        }

        public void GetAllOrders()
        {
            foreach (var order in listOfOrders)
            {
                if (order.IsDeleted == false)
                {
                    Console.WriteLine($"{order.CustomerEmail}\t{order.RefNumber}\t{order.Status}\t{order.TotalPrice}");
                    foreach (var item in order.Produce)
                    {
                        Console.WriteLine($"{item.Key}\t{item.Value}");
                    }
                }

            }
        }

        public void MakeOrder(string customerEmail, double totalPrice, Dictionary<string, int> produces)
        {
            Order order = new Order(listOfOrders.Count + 1, GenerateReferenceNumber(), customerEmail, totalPrice, DeliveryStatus.Initiated, produces);
            listOfOrders.Add(order);
            WriteOrderToFile(order);

        }

        private string GenerateReferenceNumber()
        {
            Random rand = new Random();
            return $"CLH/PRO/{rand.Next(1000000, 10000000)}";
        }

        public void SearchIfOrderReadyByRefNumber(string refNumber)
        {
            foreach (var order in listOfOrders)
            {
                if (order.RefNumber == refNumber && order.IsDeleted == false)
                {
                    order.Status = DeliveryStatus.Ready;
                }
            }
        }

        public Order SearchOrderById(int id)
        {
            foreach (var order in listOfOrders)
            {
                if (order.Id == id && order.IsDeleted == false)
                {
                    return order;
                }
            }
            return null;
        }

        public Order SearchOrderByRefNumber(string refNumber)
        {
            foreach (var order in listOfOrders)
            {
                if (order.RefNumber == refNumber && order.IsDeleted == false)
                {
                    return order;
                }
            }
            return null;
        }

        public void SearchOrderByRefNumberMenu(string refNumber)
        {
             foreach (var order in listOfOrders)
            {
                if (order.RefNumber == refNumber && order.IsDeleted == false)
                {
                    Console.WriteLine("The ");
                }
            }
            
        }


    }
}