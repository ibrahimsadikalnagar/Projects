using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class sCountry 
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }
    }
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
        public static sCountry FindCountry(int CountryID)
        {
            sCountry country = new sCountry();  
           
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Countries where ID =@CountryID"; 
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    country.Id = (int)reader["ID"];
                    country.CountryName = (string)reader["Name"];
                    country.CountryCode = (int)reader["CountryCode"];
                }


            }
            catch
            {
            }
            connection.Close() ;


          return country;
            

        }

    }
}
