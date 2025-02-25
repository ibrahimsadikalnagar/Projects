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

        

        static void Main(string[] args)
        {
     

          AddDataToCountry();
            Console.ReadKey();

        }
    }
}
