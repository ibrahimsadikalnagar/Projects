using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public static void AddCountry()
        {
           AddBusnissCountryLayer countryLayer = new AddBusnissCountryLayer();
            countryLayer.Name = "Frankrjk";
            countryLayer.CountryCode = 313;
            countryLayer.CountryInfo = "Dicht bij Nederland";
            if (countryLayer.save())
            {
                Console.WriteLine("The data saved\nID : " + countryLayer.ID);
            }
            else {
                Console.WriteLine("The data is not saved");
                    }


        }
         static void FindData(int countryID)
        {
            AddBusnissCountryLayer countryfind = AddBusnissCountryLayer.FindData(countryID);
            if (countryfind != null)
            {
                Console.WriteLine("\n" + countryfind.ID);
                Console.WriteLine("\n" + countryfind.CountryInfo);
                Console.WriteLine("\n" + countryfind.CountryCode);
                Console.WriteLine("\n" + countryfind.Name);
            }

        }

        static void UpdateD(int countryID)
        {
            AddBusnissCountryLayer countryUpdate = AddBusnissCountryLayer.FindData(countryID);
            countryUpdate.Name = "USA";
            countryUpdate.CountryCode = 0111;
            countryUpdate.CountryInfo = "In moeste land met power";
            if (countryUpdate.save())
            {
                Console.WriteLine("Saved succefully");
            }
            else
            {
                Console.WriteLine("Not Saved ");
            }
        }
        static void  DeleteDate(int countryID)
        {
            if (AddBusnissCountryLayer.DeleteDataCountry(countryID))
            {
                Console.WriteLine("Deleted successfully");
            }
            else {
                Console.WriteLine("Not Deleted");
                    }
        }
        public static void ListCountries()
        {
            DataTable dataTable = AddBusnissCountryLayer.GetAllData();

            Console.WriteLine("All Countries Data");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ID"]} , {row["Name"]} , {row["CountryCode"]}");
            }
        }
        public static void  ifDataExit(int countryID)
        {
            if (AddBusnissCountryLayer.CheckIfDataExit(countryID))
            {
                Console.WriteLine("Data exit");
            }
            else
            {
                Console.WriteLine("Data is not exit ");
            }
        }
        static void Main(string[] args)
        {
        //FindData(1008);
       // AddCountry();
     //  UpdateD(1);
    // DeleteDate(1017);
   // ListCountries();
   ifDataExit(1007);
        
            Console.ReadKey();

        }
    }
}
