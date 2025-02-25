using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnections; 

namespace DataAccess
{
 

    public class clsDataAccess
    {
        public static  bool AddData(string Name , int CountryCode , string CountryInfo )
        {
          SqlConnection connection = new SqlConnection(clsDataConnections.ConnectionStringHR);

            string query = "Insert into Countries ( Name , CountryCode , CountryInfo) " +
                "Values (@Name , @CountryCode , @CountryInfo)"; 
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Name", Name);
            sqlCommand.Parameters.AddWithValue("@CountryCode", CountryCode); 
            sqlCommand.Parameters.AddWithValue("@CountryInfo" , CountryInfo);
            try
            {
                connection.Open();
                int RowEffected = sqlCommand.ExecuteNonQuery();
                return RowEffected > 0;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;

           
        }



    }
}
