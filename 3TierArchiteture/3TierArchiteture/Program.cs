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

        public static void Find(int CountrID)
        {

           clsCountry Country =  clsCountry.FindCountrybyID(CountrID);

            Console.WriteLine("CountryID :" + Country.CountryID);
            Console.WriteLine("CountryNaam : " + Country.CountryName);
        }
       
       
        static void Main(string[] args)
        {
          
            Find(1);
            Console.ReadKey();
        }
    }
}
