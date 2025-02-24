using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnections; 

namespace DataAccess
{
 

    public class TryDataBase
    {

        public static void getData(out int id ,out string Name)
        {
            id = 0;
            Name = "Ibrahim"; 
        }
       
    }
    public class sCountry 
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }
    }
    public class clsDataAccess
    {
       
        public static string GetFirstCountryName(int CountryID)
        {
            string CountryName = "";

            SqlConnection connection = new SqlConnection(clsDataConnections.ConnectionStringHR);

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
           
            SqlConnection connection = new SqlConnection(clsDataConnections.ConnectionStringHR);
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
    public class clsDataCountry
    {
        public static void GetCoutryData(int CountryId , ref string CountryName , ref int CountryCode , ref string CountryInfo)
        {
            SqlConnection connection = new SqlConnection(clsDataConnections.ConnectionStringHR);

            string query = "Select * from Countries where ID = @CountryId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryId" , CountryId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    
                    CountryName = (string)reader["Name"];
                    CountryCode = (int)reader["CountryCode"];
                    CountryInfo = (string)reader["CountryInfo"]; 

                }

            }
            catch
            {
                Console.WriteLine("Error");
            }
            connection.Close() ;




        }
        public static int SaveCountryData(string CountryName , int CountryCode , string CountryInfo)

        {
            int CountryID = -1; 
            SqlConnection conn = new SqlConnection(clsDataConnections.ConnectionStringHR);
            string query = @"INSERT INTO Countries (Name, CountryCode, CountryInfo) 
                 VALUES (@Name, @CountryCode, @CountryInfo); 
                 SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name" , CountryName);
            cmd.Parameters.AddWithValue("@CountryCode" , CountryCode);
            cmd.Parameters.AddWithValue("@CountryInfo", CountryInfo); 
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountryID = insertedID;
                }

            }
            catch(Exception ex) { Console.WriteLine("Error");
                Console.WriteLine(ex.ToString()); }
            conn.Close();
            return CountryID;
                
        }


    }
}
