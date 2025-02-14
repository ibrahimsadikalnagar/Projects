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
        public struct stContact
        {
      
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }
        static void AddContact(stContact newContact)
        {


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                             VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@FirstName", newContact.FirstName); 
            cmd.Parameters.AddWithValue("@LastName" , newContact.LastName);
            cmd.Parameters.AddWithValue("@Email" , newContact.Email);
            cmd.Parameters.AddWithValue("@Phone" , newContact.Phone);
            cmd.Parameters.AddWithValue("@Address", newContact.Address);
            cmd.Parameters.AddWithValue("@CountryID ", newContact.CountryID);
            try
            {
                connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    Console.WriteLine("Data inserted sucssesfully ");
                }
                else
                {
                    Console.WriteLine("Record insertion failed");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }


        static void ReadData()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "select FirstName , LastName from Contacts";
            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"First Name {reader["FirstName"]} , Last Name {reader["LastName"]} \n ");

                }
                conn.Close();
                reader.Close(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            
        }

        static void AddDataMetStruct(stContact newContact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                             VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@FirstName", newContact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", newContact.LastName);
                cmd.Parameters.AddWithValue("@Email", newContact.Email);
                cmd.Parameters.AddWithValue("@Phone", newContact.Phone);
                cmd.Parameters.AddWithValue("@Address", newContact.Address);
                cmd.Parameters.AddWithValue("@CountryID ", newContact.CountryID);

                int rowEffected = cmd.ExecuteNonQuery();
                if (rowEffected > 0)
                {
                    Console.WriteLine("Data inserted sucessfully");
                }
                else
                {
                    Console.WriteLine(" Data not saved");
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }
        static void ReadCountriesData()
        {
            string query = "Select * from Countries";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                /* int CountryID = (int)reader["CountryID"];
                                 string CountryName = (string)reader["CountryName"];*/
                                //  Console.WriteLine($"CountryID: {CountryID} , CountryName : {CountryName}");
                                Console.WriteLine($"ID :{reader[0]} , {reader["CountryName"]}");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }
               


            }
               
        }
        static void ReadCountriesData(int CountryID)
        {
            string query = "Select * from Countries where CountryID = @CountryID"; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CountryID", CountryID);
                        using (SqlDataReader reader1 = cmd.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                Console.WriteLine($"ID : {reader1[0]} , Country name :{reader1[1]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }

            }
        }
        static void UpdateBYID(int ID , stContact Scontact)
        {
            string query = @"Update  Contacts  
                            set FirstName = @FirstName, 
                                LastName = @LastName, 
                                Email = @Email, 
                                Phone = @Phone, 
                                Address = @Address, 
                                CountryID = @CountryID
                                where ContactID = @ContactID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue(@"ContactID" , ID);
                        cmd.Parameters.AddWithValue("@FirstName", Scontact.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", Scontact.LastName);
                        cmd.Parameters.AddWithValue("@Email", Scontact.Email);
                        cmd.Parameters.AddWithValue("@Phone", Scontact.Phone);
                        cmd.Parameters.AddWithValue("@Address", Scontact.Address);

                        cmd.Parameters.AddWithValue("@CountryID", Scontact.CountryID);

                        int rawEffected = cmd.ExecuteNonQuery();
                        if (rawEffected > 0)
                        {
                            Console.WriteLine("Update sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("something wrong check with your data");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }
            }

        }

        static void DeleteRowsFromTables(int ContactID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"Delete from Contacts where ContactID = @ContactID ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                    
                {
                    cmd.Parameters.AddWithValue("@ContactID", ContactID);
                    try
                    {
                        connection.Open();
                        int rawEffected = cmd.ExecuteNonQuery();
                        if (rawEffected > 0)
                        {
                            Console.WriteLine("Sucssessfullly Deleted");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error" + ex.Message);
                    }
                }
            }
        }

            static void Main(string[] args)
            {
            // To practice in update with sql table 

           /* stContact sContact = new stContact()
            {
                FirstName = "ISA",
                LastName = "2Pacc",
                Email = "PacEsms@gmail.com"
                ,
                Phone = "2525452",
                Address = "Daa431",
                CountryID = 1
            };

            UpdateBYID(12, sContact);*/

            DeleteRowsFromTables(12);













            // create basic connection using ( using statment for automatic close the connection

            /*//**   ReadCountriesData();
                Console.WriteLine("Enter the number of the countries that you want to know");

                int CountryID = Convert.ToInt32(Console.ReadLine());*//*

                ReadCountriesData(CountryID);*/


            /* string input = "exit";
             while (true)
             {
               input =   Console.ReadLine(); 
                 if (input.ToLower() == "exit")
                 {
                     Console.WriteLine("Data is exiting ");
                     break;
                 }
             }*/


            /* stContact contact = new stContact()
             {
                 FirstName = "Ismail" , LastName = "Alangar" , Email = "Ismail@gmail.com" , 
                 Phone = "23232" , Address = "Hadda 3434" , CountryID = 3 
             }; 
             AddDataMetStruct(contact);*/


            /* stContact contact1 = new stContact()
             {

                 FirstName = "Ibrahim",
                 LastName = "Alnagar",
                 Email = "Alnajjar@gmail.com",
                 Phone = "3434343",
                 Address = "ArnHel324",
                 CountryID = 1
             };
             AddContact(contact1);*/

            //PrintAllContacts("Jane" , 1);
            // PrintAllContacts("Jane"); 

            //  Console.WriteLine("Search for 'ne' ");
            //SearchForFirstTwoCharacter("J");
            // SearchForFirstTwoCharacter("ne");
            // Console.WriteLine(GetFirstName(1)); 

            // to find one record 
            /* SContact sContact = new SContact();
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
*/




            Console.ReadKey();
            }
        
    }
}
