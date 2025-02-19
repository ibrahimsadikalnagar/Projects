using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessContactLayer
{
    public class clsContactDataAccess
    {
        public static bool GetContactInfoByID(int ID , ref string FirstName , ref string LastName
            , ref string Address , ref string Email , ref string Phone , 
            ref string ImagePath , ref DateTime DateOfBirth , ref int CountryID)
        {
            bool isFound = false; 
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "select * from Contacts where ContactID = @ContactID"; 
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ContactID", ID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];
                    ImagePath = (string)reader["ImagePath"];

                }
                else
                {
                    isFound = false;

                }
                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        static string connections = "Server=.;Database=ContactsDB;User Id=sa;Password=123456";

        public static void PrintAllRecordsContacts()
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
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
}
