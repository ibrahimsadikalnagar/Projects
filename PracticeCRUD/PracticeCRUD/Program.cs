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
            int  id = 0;
            string Name = ""; 
            TryBusniess data = TryBusniess.GetData1();
            Console.WriteLine($"ID : {data.Id} , Name: {data.Name}");
        }
        

        static void Main(string[] args)
        {
            /*Console.WriteLine(  clsDataAccess.GetFirstCountryName(4));*/
          print();
            Console.ReadKey(); 
        }
    }
}
