using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class Produce
    {
        public int Id { get; set; }
        public string ProduceName { get; set; }
        public string SerialNumber { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public ProduceCategory Category { get; set; }
        public int FarmerId { get; set; }
        public bool IsDeleted {get; set;}


        public Produce(int id, string produceName, string serialNumber, double price, double quantity, ProduceCategory category, int farmerId)
        {
            Id = id;
            ProduceName = produceName;
            SerialNumber = serialNumber;
            Price = price;
            Quantity = quantity;
            Category = category;
            FarmerId = farmerId;
          
        }

        
        public  override string ToString()
        {
            return $"{Id}%%%%{ProduceName}%%%%{SerialNumber}%%%%{Price}%%%%{Quantity}%%%%{Category}%%%%{FarmerId}%%%%{IsDeleted}";
        }
         
        public static Produce ToProduce(string produce)
        {
            var produceStr = produce.Split("%%%%");
            int id = int.Parse(produceStr[0]);
            string produceName = produceStr[1];
            string serialNumber = produceStr[2];
            double price = double.Parse(produceStr[3]);
            double quantity = double.Parse(produceStr[4]);
            ProduceCategory category = (ProduceCategory)Enum.Parse(typeof(ProduceCategory), produceStr[5]);
            int farmerId = int.Parse(produceStr[6]);
            bool isDeleted = bool.Parse(produceStr[7]);

            var produceObject = new Produce(id,produceName, serialNumber,price, quantity, category, farmerId);
            produceObject.IsDeleted = isDeleted;
            return produceObject;

        }
    }
}