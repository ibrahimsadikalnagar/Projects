using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer; 


namespace ContactsBusinessLayers
{
    public class clsCountry
    {
        public enum enMode {AddNew = 0 , Update =  1 }  
        enMode Mode = enMode.AddNew;
        public int CountryID {  get; set; }
        public string CountryName { get; set; }

        public clsCountry() 
        { 
            CountryID = -1;
            CountryName = ""; 
            Mode = enMode.AddNew;

        }


        public clsCountry(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        private bool _AddCountry()
        {
            this.CountryID = clsContactDataAccess.AddNewCountry(this.CountryName);
            return (this.CountryID != -1); 
        }
      

                    

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddCountry())
                    {
                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false; 
        }







        public static clsCountry FindCountrybyID(int cID)
        {
            string CountryNaam = "";
            clsContactDataAccess.getCountrybyID(cID, ref CountryNaam);
            return new clsCountry(cID , CountryNaam);
        }

      

    }


   
}
