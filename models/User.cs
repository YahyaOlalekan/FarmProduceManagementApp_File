
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProduceManagementApp_File.enums;

namespace FarmProduceManagementApp_File.models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Pin { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted {get; set;}


        public User(int id, string name, string email, string address, string phoneNumber, int pin, Gender gender)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
            Pin = pin;
            Gender = gender;
            
        }
        public User()
        {
            
        }
        
        public  override string ToString()
        {
            return $"{Id}\t{Name}\t{Email}\t{Address}\t{PhoneNumber}\t{Pin}\t{Gender}\t{IsDeleted}";
        }
         
        public static User ToUser(string user)
        {
            var userStr = user.Split('\t');
            int id = int.Parse(userStr[0]);
            string name = userStr[1];
            string email = userStr[2];
            string address = userStr[3];
            string phoneNumber = userStr[4];
            int pin = int.Parse(userStr[5]);
            Gender gender = (Gender) Enum.Parse(typeof(Gender), userStr[6]);
            bool isDeleted = bool.Parse(userStr[7]);
           
            return new User(id, name, email, address, phoneNumber, pin, gender);
        }
        
    }
}