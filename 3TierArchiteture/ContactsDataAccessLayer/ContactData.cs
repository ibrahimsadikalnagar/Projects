using System;
using System.Data.SqlClient;
using System.Data; 

namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {
        public static bool GetContactInfoByID(int ID , ref string FirstName , ref string LastName , 
            ref string Address , ref string Phone , ref string Email , ref string ImagePath 
            , ref DateTime DateOfBirth , ref int CountryID )
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * from Contacts where ContactID = @ContactID"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue( "@ContactID", ID );

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
        public static bool GetCountryInfoByID(int ID , ref string CtyName)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * from Countries where CountryID = @CountryID"; 
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@CountryID", ID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CtyName = (string)reader["CountryName"];
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
        public static void  PrintAllCountriesData(ref int ID , ref string CNaam)
        {

            ID = 0;
            CNaam = " Jaman";
        }
    }

    public class clsCountries
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
       
       
    }
   
}
