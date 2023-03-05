using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class Order
    {
        public int Id { get; set; }
        public string RefNumber { get; set; }
        public string CustomerEmail { get; set; }
        public double TotalPrice { get; set; }
        public DeliveryStatus Status { get; set; }
        public Dictionary<string, int> Produce { get; set; }
        public bool IsDeleted {get; set;}


        public Order(int id, string refNumber, string customerEmail, double totalPrice, DeliveryStatus status, Dictionary<string, int> produce)
        {
            Id = id;
            RefNumber = refNumber;
            CustomerEmail = customerEmail;
            TotalPrice = totalPrice;
            Status = status;
            Produce = produce;
            

        }

        public override string ToString()
        {
            string c = $"{Id}\t{RefNumber}\t{CustomerEmail}\t{TotalPrice}\t{Status}\t{IsDeleted}\t";
            foreach (var item in Produce)
            {
                c += $"{item.Key}->{item.Value}/";
            }
            var returned = c.Remove(c.Length-1);
            return returned;
        }

        public static Order ToOrder(string order)
        {
            var orderStr = order.Split('\t');
            int id = int.Parse(orderStr[0]);
            string refNumber = orderStr[1];
            string customerEmail = orderStr[2];
            double totalprice = double.Parse(orderStr[3]);
            DeliveryStatus status = (DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), orderStr[4]);
            bool isDeleted = bool.Parse(orderStr[5]);

            var arr = orderStr[6].Split('/');
            Dictionary<string, int> prod = new Dictionary<string, int>();
            foreach (var item in arr)
            {
                var produce = item.Split("->");
                var key = produce[0];
                var value = int.Parse(produce[1]);
               prod.Add(key, value);
            }

            var orderObject = new Order(id, refNumber, customerEmail, totalprice, status, prod);
            orderObject.IsDeleted = isDeleted;
            return orderObject;

        }

    }
}