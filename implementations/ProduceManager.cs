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
    public class ProduceManager : IProduceManager
    {
        public static List<Produce> listOfProduces = new List<Produce>();
        string file = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files\produce.txt";
        public ProduceManager()
        {
            if (listOfProduces.Count == 0)
            {
                ReadProduceFromFile();
            }
        }

        public void ReadProduceFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var produce = File.ReadAllLines(file);
                    if(produce.Length > 0)
                    {
                        foreach (var item in produce)
                        {
                        listOfProduces.Add(Produce.ToProduce(item));
                        }
                    }
                    
                }
                else
                {
                    string path = @"C:\Users\USER PC\Desktop\FarmProduceManagementApp_File\Files";
                    Directory.CreateDirectory(path);
                    string fileName = "produce.txt";
                    string fullPath = Path.Combine(path, fileName);
                    File.Create(fullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteProduceToFile(Produce produce)
        {
            try
            {
                using (var write = new StreamWriter(file, true))
                {
                    write.WriteLine(produce.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       



        public void AddProduce(string produceName, double price, int quantity, ProduceCategory category, int farmerId)
        {
            var produceExists = CheckIfExists(produceName);
            if (produceExists != null)
            {
                produceExists.Quantity += quantity;
                Console.WriteLine("The quantity is successfully updated");
                Console.WriteLine();

            }
            else
            {
                var produce = new Produce(listOfProduces.Count + 1, produceName, GenerateSerialNumber(), price, quantity, category, farmerId);

                listOfProduces.Add(produce);
                WriteProduceToFile(produce);
                //Console.WriteLine($"{farmerId}\t{listOfProduces.Count}");
                Console.WriteLine($"{produceName} added successfully, quantity in stock is {quantity}");
                Console.WriteLine($"Total amount of your produce sold is #{price * quantity}");

                Console.WriteLine();
            }
        }

        private Produce CheckIfExists(string produceName)
        {
            foreach (var produce in listOfProduces)
            {
                if (produce.ProduceName == produceName && produce.IsDeleted == false)
                {
                    return produce;
                }
            }
            return null;
        }

        public void GetAllProduces()
        {
            foreach (var produce in listOfProduces)
            {
                if(produce.IsDeleted == false)
                Console.WriteLine($"produce name:{produce.ProduceName}\tserial number:{produce.SerialNumber}\tquantity:{produce.Quantity}\tprice:{produce.Price}");
            }
        }

        public List<Produce> GetProducesByfarmerId(int farmerId)
        {
            List<Produce> produces = new List<Produce>();
            foreach (var produce in listOfProduces)
            {
                if (produce.FarmerId == farmerId && produce.IsDeleted == false)
                {
                    produces.Add(produce);
                }
            }
            return produces;
        }

        public Produce GetProduceById(int id, int categoryId, double quantity)
        {
            foreach (var produce in listOfProduces)
            {
                if (produce.Id == id && (int)produce.Category == categoryId && produce.IsDeleted == false && produce.Quantity >= quantity)
                {
                    return produce;
                }
            }
            return null;
        }

        public Produce GetProduceByProduceName(string produceName)
        {
            foreach (var produce in listOfProduces)
            {
                if (produce.ProduceName == produceName && produce.IsDeleted == false)
                {
                    return produce;
                }
            }
            return null;
        }



        public string GenerateSerialNumber()
        {
            return "SN/00" + (listOfProduces.Count + 1);
        }

        public void GetProduceByProduceNameMenu()
        {
            throw new NotImplementedException();
        }


    }
}