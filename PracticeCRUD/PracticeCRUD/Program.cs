using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace PracticeCRUD
{
    internal class Program
    {
       

        

        static void Main(string[] args)
        {
            Console.WriteLine(  clsDataAccess.GetFirstCountryName(4));
            Console.ReadKey(); 
        }
    }
}
