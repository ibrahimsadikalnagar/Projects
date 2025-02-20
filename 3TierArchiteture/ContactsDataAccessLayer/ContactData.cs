using System;
using System.Data.SqlClient;
using System.Data;

using System.Net.Http.Headers;
using System.Collections.Generic;
using System.ComponentModel;

namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {




        public static int AddNewCountry(string countryName)
        {
            int countryId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Countries (CountryName, )
                             VALUES (@CountryName);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", countryName);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    countryId = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                connection.Close(); 
            }

            return countryId;
        }













        public static void getCountrybyID(int countryID , ref string CountryNaam)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString );
            string query = " Select * from Countries where CountryID =@CountryID"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CountryID", countryID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CountryNaam = (string)reader["CountryName"];
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            conn.Close();
            
        }

        
          

    }



  
}
