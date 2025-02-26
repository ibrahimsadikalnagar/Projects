using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
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

        public static int AddNewData(string  Name , int CountryCode , string CountryInfo )
        {
           int  CountryID = -1; 
            SqlConnection connection = new SqlConnection(clsDataConnections.ConnectionStringHR); 
            string query = @"Insert into Countries ( Name , CountryCode , CountryInfo) " +
                "Values (@Name , @CountryCode , @CountryInfo)"+ 
                            " SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@CountryCode", CountryCode);
            command.Parameters.AddWithValue("@CountryInfo", CountryInfo);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountryID = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error to save data in Data Access Layer", ex.Message);
            }

            finally
            {
                connection.Close();
            }


            return CountryID;
        }


    }
}
