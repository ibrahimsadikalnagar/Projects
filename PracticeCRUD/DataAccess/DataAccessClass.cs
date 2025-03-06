using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataConnections; 

namespace DataAccess
{
 

    public class clsDataAccess
    {
       
        
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

        public static bool FindDataByID(int ID , ref string Name , ref int CountryCode , ref string CountryInfo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnections.ConnectionStringHR);
            string query = "Select * from Countries where ID = @ID "; 
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID" , ID);
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    Name = (string)Reader["Name"];
                    CountryCode = (int)Reader["CountryCode"];
                    CountryInfo = (string)Reader["CountryInfo"];

                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error for inserting data" + ex.Message);
            }
            connection.Close();
            
            return isFound;

        }

        public static bool UpdateData(int ID, string Name, int CountryCode, string CountryInfo)
        {
            int rowEffected = 0;
            SqlConnection conn = new SqlConnection(clsDataConnections.ConnectionStringHR);
            string query = @"update Countries 
                            set Name =@Name, CountryCode =@CountryCode , CountryInfo=@CountryInfo
                                where ID =@ID";
            SqlCommand Command = new SqlCommand(query, conn);
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@CountryCode", CountryCode);
            Command.Parameters.AddWithValue("@CountryInfo", CountryInfo);
            Command.Parameters.AddWithValue("@ID", ID); 
            try
            {
                conn.Open();
                rowEffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            conn.Close();
            return rowEffected > 0;
        }
        public static bool DeleteData(int ID)
        {
            int RowEffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataConnections.ConnectionStringHR);
            string query = @"Delete Countries where ID =@ID";
            SqlCommand Cmd = new SqlCommand(query, Connection);
            Cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                Connection.Open();
                RowEffected = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            Connection.Close();
            return RowEffected > 0;
        }

        public static DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            SqlConnection  conn = new SqlConnection(clsDataConnections.ConnectionStringHR);
            string query = "Select * from Countries"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex) { Console.WriteLine("eRROR IN database" + ex.Message); }
            finally
            {

                conn.Close();
            }

            return dt;

        }

        public static bool IfExitData(string Name)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataConnections.ConnectionStringHR);
            string query = "select * from Countries where LOWER(Name) = LOWER(@Name)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name" , Name);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows; 
            }
            catch (Exception ex) { Console.WriteLine("Error in database layer" + ex.Message); }
            finally

            {
                conn.Close();
            }
            return isFound;
        }
        public static bool GetCountryByName(string CountryName, ref int CountryID
            , ref int CountryCode, ref string CountryInfo)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataConnections.ConnectionStringHR);
            string query = "Select * from Countries where Name = @CountryName";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                conn.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    CountryID = (int)Reader["ID"];
                    CountryCode = (int)Reader["CountryCode"];
                    CountryInfo = (string)Reader["CountryInfo"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                conn.Close();
            }
            return isFound;
        }


    }
}
