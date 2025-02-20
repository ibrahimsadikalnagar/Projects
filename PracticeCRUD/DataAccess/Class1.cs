using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsDataAccess
    {
        static string ConnectionString = "Server=.;Database=HR_Database;User Id=sa;Password=123456;";


       public static string GetFirstCountryName(int CountryID)
        {
            string CountryName = "";

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "select * from Countries ";
            SqlCommand command = new SqlCommand(query, connection);
            //  command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    CountryName = Result.ToString();
                }
                else
                {
                    CountryName = "";
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            return CountryName;

        }
    }
}
