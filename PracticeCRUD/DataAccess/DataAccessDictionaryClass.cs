using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnections; 

namespace DataAccess
{
   public class clsDataAccessWords
    {
        public static DataTable GetAllWords()
        {
            DataTable tables = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnections.ConnectionStringWords);
            string query = "Select * from Words"; 
            SqlCommand cmd = new SqlCommand(query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    tables.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return tables;
        }
        public static int AddNewWord(string Word, string Translate, int WordTypeID)
        {
            int WordID = -1; 
            SqlConnection   conn = new SqlConnection(clsDataConnections.ConnectionStringWords);
            string query = @"Insert into Words (Word, Translate , WordTypeID)
                Values (@Word , @Translate , @WordTypeID);
                 SELECT SCOPE_IDENTITY()";

            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@Word", Word); 
            comm.Parameters.AddWithValue("@Translate" , Translate);
            comm.Parameters.AddWithValue("@WordTypeID", WordTypeID);
            try
            {
                conn.Open();
                object result = comm.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    WordID = InsertedID;
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        return WordID;

        }
    }
}
