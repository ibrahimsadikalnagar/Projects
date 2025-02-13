using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Policy;
using static ConsoleDataConnectionSql.Program;

namespace ConsoleDataConnectionSql
{
    internal class Program
    {
        static String connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456; ";
        static void PrintAllContacts()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String query = "Select * from Contacts";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Email"];

                    Console.WriteLine($"Contact ID: {ContactID}   ");
                    Console.WriteLine($"First Name :  {FirstName}  ");
                    Console.WriteLine($"Last Name : {LastName}  " );
                    Console.WriteLine($"Email Address : {email} ");
                    Console.WriteLine($"Phone Number : {Phone}  \n  ");
                }
                reader.Close();
                connection.Close();

                }
                catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }

        }
        static void PrintAllContacts(string FirstName , int CountryID)
        {
            SqlConnection connection = new SqlConnection (connectionString);
            string query = "Select * from Contacts where FirstName = @FirstName and CountryID = @CountryID ";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string email = (string)reader["email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"]; 

                    Console.WriteLine($"ContactID : {ContactID} , Name :" +
                        $" {firstName} { LastName} , Email : {email} , Phone : {Phone} , " +
                        $"Address : {Address} , CountryID : {countryID} \n ");

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : "+ ex.Message);
            }

        }
        static void PrintAllContacts(string FirstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where Contacts.FirstName = 'Jane'";


            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue(@FirstName, FirstName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string email = (string)reader["email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID : {ContactID} , Name :" +
                       $" {firstName} {LastName} , Email : {email} , Phone : {Phone} , " +
                       $"Address : {Address} , CountryID : {countryID} \n ");


                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connection");
            }
        }
        static void SearchForFirstTwoCharacter(string TwoChar)
        { 
            SqlConnection connection = new SqlConnection( connectionString);
            string query = "select * from Contacts where Contacts.FirstName like '%' + @TwoChar +'%'"; 
            SqlCommand cmd = new SqlCommand(query , connection);
            cmd.Parameters.AddWithValue("@TwoChar", TwoChar);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string email = (string)reader["email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {ContactID}");
                    Console.WriteLine($"Name: {firstName} {LastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }
                reader.Close ();
                connection.Close();
            }

            
            catch (Exception ex)
            {
                Console.WriteLine("error connection");
            }
        }

        static string GetFirstName(int ContactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string FirstName = "";
            string query = "select Contacts.FirstName from Contacts where Contacts.ContactID = @ContactID ";
        
            SqlCommand cmd = new SqlCommand(query , connection);
            cmd.Parameters.AddWithValue("@ContactID", ContactID);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar(); 
                if(result != null )
                {
                    FirstName = result.ToString(); 

                }
                else
                { FirstName = " ";
                }
                connection.Close();
            }
            catch (Exception ex) { 
                Console.WriteLine("Error " + ex.ToString());
            }

            return FirstName;
        
        }
        public struct SContact
        {
            public int ContactID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }
        static bool FindFirstRecord(int ContactID, ref SContact contactInfo)
        {
           bool isFound = false;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    contactInfo.ContactID = (int)reader["ContactID"];
                    contactInfo.FirstName = (string)reader["FirstName"];
                    contactInfo.LastName = (string)reader["LastName"];
                    contactInfo.Email = (string)reader["Email"];
                    contactInfo.Address = (string)reader["Address"];
                    contactInfo.CountryID = (int)reader["CountryID"];


                }
                else
                {
                    isFound = false;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
            return isFound;
        }

        static bool FindContactByID(int ContactID, ref SContact ContactInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    ContactInfo.ContactID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            return isFound;
        }

            static void Main(string[] args)
            {




                //PrintAllContacts("Jane" , 1);
                // PrintAllContacts("Jane"); 

                //  Console.WriteLine("Search for 'ne' ");
                //SearchForFirstTwoCharacter("J");
                // SearchForFirstTwoCharacter("ne");
                // Console.WriteLine(GetFirstName(1)); 

                SContact sContact = new SContact();
                if (FindFirstRecord(1, ref sContact))
                {
                    Console.WriteLine($"\nContanctID : {sContact.ContactID}");
                    Console.WriteLine($"FirstName : {sContact.FirstName}");
                    Console.WriteLine($"LastName : {sContact.LastName}");
                    Console.WriteLine($"Email : {sContact.Email}");
                    Console.WriteLine($"Phone : {sContact.Phone}");
                    Console.WriteLine($"Address : {sContact.Address}");
                    Console.WriteLine($"Country ID :{sContact.CountryID}");
                }
                else
                {
                    Console.WriteLine("Contact is not found");
                }




                Console.ReadKey();
            }
        
    }
}
