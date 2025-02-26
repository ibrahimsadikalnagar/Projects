using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace PracticeCRUD
{
    internal class Program
    {

        public static void AddDataToCountry()
        {
            clsAddCountry Country = new clsAddCountry();

            Country.CountryName = "UK";
            Country.CountryCode = 0032;
            Country.CountryInfo = "Niet meer Eroup union"; 

            bool Sucess = clsAddCountry.AddCountry(Country);

            if (Sucess)
            {
                Console.WriteLine("Success Saved ");
            }
            else
            {
                Console.WriteLine("Not saved");
            }
        }

        public static void AddCountry()
        {
           AddBusnissCountryLayer countryLayer = new AddBusnissCountryLayer();
            countryLayer.Name = "Belgie";
            countryLayer.CountryCode = 311;
            countryLayer.CountryInfo = "Dicht bij Nederland";
            if (countryLayer.save())
            {
                Console.WriteLine("The data saved" + countryLayer.ID);
            }
            else {
                Console.WriteLine("The data is not saved");
                    }


        }

        static void Main(string[] args)
        {
     

          //AddDataToCountry();
          AddCountry();
            Console.ReadKey();

        }
    }
}
