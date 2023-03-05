using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.interfaces
{
    public interface IProduceManager
    {
         public void AddProduce(string productName, double price, int quantity, ProduceCategory category, int farmerId);
        public Produce GetProduceById(int id , int categoryId,double quantity);
        public Produce GetProduceByProduceName(string productName);
        public void GetAllProduces();
        public void GetProduceByProduceNameMenu();
        public string GenerateSerialNumber();
        List<Produce> GetProducesByfarmerId(int farmerId);
        
    }
}