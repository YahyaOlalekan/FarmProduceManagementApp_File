using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class Transaction
    {
        public static IList<Transaction> Transactions = new List<Transaction>();
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProduceCategory Category { get; set; }
        public string ProductName { get; set; }
        public string Email { get; set; }
        public double Quantity { get; set; }
        
        public Transaction(int id, int productId, ProduceCategory category, string productName, string email, double quantity)
        {
            Id = id;
            ProductId = productId;
            Category = category;
            ProductName = productName;
            Email = email;
            Quantity = quantity;
        }

       
        public override string ToString()
        {
            return $"{Id}\t{ProductId}\t{Category}\t{ProductName}\t{Email}\t{Quantity}";
        }

        public static Transaction ToTransaction(string transaction)
        {
            var transactionStr = transaction.Split('\t');
            int id = int.Parse(transactionStr[0]);
            int productId = int.Parse(transactionStr[1]);
            ProduceCategory category = (ProduceCategory)Enum.Parse(typeof(ProduceCategory), transactionStr[2]);
            string productName = transactionStr[3];
            string email = transactionStr[4];
            double quantity = double.Parse(transactionStr[5]);

            return new Transaction(id, productId, category, productName, email, quantity);

        }


    }
}