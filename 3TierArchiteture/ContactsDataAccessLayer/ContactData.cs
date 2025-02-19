using System;
using System.Data.SqlClient;
using System.Data;

using System.Net.Http.Headers;
using System.Collections.Generic;

namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {
       
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
