using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCountries
{
    public class clsDataAccessCountries
    {
        static string connections = "Server=.;Database=ContactsDB;User Id=sa;Password=123456";

        public static void PrintAllRecordsContacts()
        {
            SqlConnection conn = new SqlConnection(connections);
            string query = "Select * from Countries";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    {
                        int CountryId = (int)Reader[0];
                        string CountryNaam = (string)Reader[1];

                        Console.WriteLine("ID : " + CountryId);
                        Console.WriteLine("CountryName: " + CountryNaam + "\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("eRROR" + ex.Message);
            }

        }
    }
}
