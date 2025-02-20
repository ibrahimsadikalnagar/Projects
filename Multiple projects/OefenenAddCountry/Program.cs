using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OefenenAddCountry;


namespace OefenenAddCountry
{
    internal class Program
    {
        public struct sCountry
        {

            public string CountryName;
            public int CountryCode;
        }
        static string connections = "Server=.;Database=HR_Database;User Id=sa;Password=123456";

        static void AddCountry(sCountry newCountry)
        {
        
            SqlConnection conn = new SqlConnection(connections);
            string query = @"insert into Countries (Name , CountryCode) 
                            values (@Name , @CountryCode)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Name", newCountry.CountryName);
            cmd.Parameters.AddWithValue("@CountryCode", newCountry.CountryCode);
            try
            {
                conn.Open();
                int RowEffected = cmd.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    Console.WriteLine("Data inserted ");
                }
                else
                {
                    Console.WriteLine("Data not inserted ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();



                               
        }
        static void Main(string[] args)
        {
            sCountry sC1 = new sCountry { CountryName = "Yemen" , CountryCode = 00967 }; 
             
            AddCountry(sC1); 
            Console.ReadKey();
        }
    }
    public class clsCountries
    {
        public string CountryName { get; set; }
        public int CountryCode { get; set; }

        public clsCountries(string countryName, int countryCode)
        {
            CountryName = countryName;
            CountryCode = countryCode;
        }
        public static clsCountries GetCountries()
        {


            return new clsCountries()
        }
}
