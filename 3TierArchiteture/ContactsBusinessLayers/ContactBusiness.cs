using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayers
{
    public class clsContact
    {
        public int ID  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public string ImagePath { get; set; }
       public int CountryID { get; set; }


        public clsContact(int iD, string firstName, string lastName, string email, string phone, string address, DateTime dateOfBirth, string imagePath, int countryID)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            DateOfBirth = dateOfBirth;
            ImagePath = imagePath;
            CountryID = countryID;
        }

        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "",
                Address = "" , ImagePath ="";
            DateTime DateOfBirth =  DateTime.Now; 
            int CountryID = 0;
            if(clsContactDataAccess.GetContactInfoByID(ID ,ref FirstName,
               ref LastName,ref Email,ref Phone,ref Address,
               ref ImagePath,ref DateOfBirth,ref CountryID))

            return new clsContact(ID, FirstName ,
                LastName , Email, Phone ,Address , DateOfBirth, ImagePath,  CountryID);           
            else 
                return null;

        }

    }

    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        public clsCountry(int id, string countryName)
        {
            ID = id;
            CountryName = countryName;
        }

        public static clsCountry Find(int ID) {
            return clsCountry(ID ,ref CountryName);
    }


   
}
