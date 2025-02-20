using DataAccessContactLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBusinessLayer
{
    public class clsContact
    {
        public enum enMode { AddNew = 0 , Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath {  get; set; }
        public int CountryID { get; set; }  

        public clsContact()
        {
            this.ID = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = ""; 
            this.CountryID = 0;
            Mode = enMode.AddNew;
        }
       private clsContact(int ID , string FirstName , string LastName , string Address,
           string Phone , string Email , DateTime DateOfBirth ,
           string ImagePath , int CountryID)
        {
            this.ID = ID;
            this.FirstName = FirstName;
                this.LastName = LastName;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            this.CountryID = CountryID;
            Mode = enMode.AddNew;

        }
      
           

              

        }



    }
}
