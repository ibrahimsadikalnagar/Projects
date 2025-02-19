using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer; 


namespace ContactsBusinessLayers
{
    public class clsCountry
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }

        public clsCountry(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        public static clsCountry FindCountrybyID(int cID)
        {
            string CountryNaam = "";
            clsContactDataAccess.getCountrybyID(cID, ref CountryNaam);
            return new clsCountry(cID , CountryNaam);
        }
    }


   
}
