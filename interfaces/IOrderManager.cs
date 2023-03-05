using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.models;

namespace FarmProduceManagementApp_File.interfaces
{
    public interface IOrderManager
    {
         public Order SearchOrderById(int id);
        public Order SearchOrderByRefNumber(string refNumber);
        public void GetAllOrders();
        public void SearchIfOrderReadyByRefNumber(string refNumber);
        public void CancelOrderByRefNumber(string refNumber);
        public void MakeOrder(string customerEmail, double totalPrice, Dictionary<string, int> produces);
        //void SearchOrderByRefNumberMenu();
    }
}