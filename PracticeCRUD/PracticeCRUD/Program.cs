using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace PracticeCRUD
{
    internal class Program
    {

        static void print()
        {
            int  id;
            string Name ; 
            TryBusniess data = TryBusniess.GetData1();
            Console.WriteLine($"ID : {data.Id} , Name: {data.Name}");
        }

        static void PrintCountry(int ID)
        {
            clsCountry country = clsCountry.GetAllDataCountry(ID);
            Console.WriteLine($"ID: {country.CountryId} ," +
                $" \n Country Name : {country.CountryName} ," +
                $"\n Country Code : {country.CountryCode} ," +
                $"\n Country Information {country.CountryInfo} ");
                 
        }
        
        public static void  AddToCountry()
        {
            clsCountry Country = new clsCountry( "Egypt" , 0021 ,"i like paramits");
           
            Country.SaveCountryData();

        }

        static void Main(string[] args)
        {
            /*Console.WriteLine(  clsDataAccess.GetFirstCountryName(4));*/
        //  print();
         //   PrintCountry(1004);
         AddToCountry();

          
            Console.ReadKey();

        }
    }
}
