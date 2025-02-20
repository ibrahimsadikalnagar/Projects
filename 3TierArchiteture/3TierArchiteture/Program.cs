using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBusinessLayers; 

namespace _3TierArchiteture
{
    internal class Program
    {

        public static void AddNew()
        {
            clsCountry Country1 = new clsCountry();
            
            Country1.CountryName = "Yemen"; 

            if(Country1.Save())
            {
                Console.WriteLine("Country add successfully with Id = " + Country1.CountryID);
            }

        }






        public static void Find(int CountrID)
        {

           clsCountry Country =  clsCountry.FindCountrybyID(CountrID);

            Console.WriteLine("CountryID :" + Country.CountryID);
            Console.WriteLine("CountryNaam : " + Country.CountryName);
        }
       
       
       
        static void Main(string[] args)
        {
          
           // Find(1);
           AddNew();
            Console.ReadKey();
        }
    }
}
