using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PracticeCRUD
{
    internal class Program
    {

        public static void AddCountry()
        {
           AddBusnissCountryLayer countryLayer = new AddBusnissCountryLayer();
            countryLayer.Name = "Frankrjk";
            countryLayer.CountryCode = 313;
            countryLayer.CountryInfo = "Dicht bij Nederland";
            if (countryLayer.save())
            {
                Console.WriteLine("The data saved\nID : " + countryLayer.ID);
            }
            else {
                Console.WriteLine("The data is not saved");
                    }


        }
         static void FindData(int countryID)
        {
            AddBusnissCountryLayer countryfind = AddBusnissCountryLayer.Find(countryID);
            if (countryfind != null)
            {
                Console.WriteLine("\n" + countryfind.ID);
                Console.WriteLine("\n" + countryfind.CountryInfo);
                Console.WriteLine("\n" + countryfind.CountryCode);
                Console.WriteLine("\n" + countryfind.Name);
            }

        }

        static void UpdateD(int countryID)
        {
            AddBusnissCountryLayer countryUpdate = AddBusnissCountryLayer.Find(countryID);
            countryUpdate.Name = "USA";
            countryUpdate.CountryCode = 11;
            countryUpdate.CountryInfo = "Ik droom om te bezoek";
            if (countryUpdate.save())
            {
                Console.WriteLine("Saved succefully");
            }
            else
            {
                Console.WriteLine("Not Saved ");
            }
        }
        static void  DeleteDate(int countryID)
        {
            if (AddBusnissCountryLayer.DeleteDataCountry(countryID))
            {
                Console.WriteLine("Deleted successfully");
            }
            else {
                Console.WriteLine("Not Deleted");
                    }
        }
        public static void ListCountries()
        {
            DataTable dataTable = AddBusnissCountryLayer.GetAllData();

            Console.WriteLine("All Countries Data");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ID"]} , {row["Name"]} , {row["CountryCode"]}");
            }
        }
        public static void  ifDataExit(string countryName)
        {
            if (AddBusnissCountryLayer.CheckIfDataExit(countryName))
            {
                Console.WriteLine("Data exit");
            }
            else
            {
                Console.WriteLine("Data is not exit ");
            }
        }
        public static void FindByName(string name)
        {
            AddBusnissCountryLayer Country =  AddBusnissCountryLayer.Find(name);
            if (Country != null)
            {
                Console.WriteLine(Country.Name);
                Console.WriteLine(Country.ID);
                Console.WriteLine(Country.CountryCode);
                Console.WriteLine(Country.CountryInfo);
            }
            else
            {
                Console.WriteLine("Country not found"); 
            }
            
        }
        public static int  GetIDbyName(string name)
        {
            int ID = AddBusnissCountryLayer.Find(name).CountryCode;
            return ID;
        }

        static void Main(string[] args)
        {
            // FindByName("USA");
            // Console.WriteLine(GetIDbyName("USA")); 
            //FindData(1008);
            //AddCountry();
            //UpdateD(2);
            // DeleteDate(1017);
            // ListCountries();
            // ifDataExit("USA");
            DataTable ContactTable = new DataTable();
            ContactTable.Columns.Add("ID", typeof(int));
            ContactTable.Columns.Add("Name", typeof(string));
            ContactTable.Columns.Add("Salaris", typeof(double));
        

            //Add rows 
            ContactTable.Rows.Add(1, "Ibrahim Alnagar" ,4300);
            ContactTable.Rows.Add(2, "Tim Elbeed",3500);
            ContactTable.Rows.Add(3, "Yossif Ibra", 3399);
            ContactTable.Rows.Add(4, "Ward Algeer", 4200);
            ContactTable.Rows.Add(5, "Bavik Roty", 5600);

            int EmployeeCount = 0;
            Double TotalSalaris = 0;   
            Double AverageSalaris = 0;
            Double MaxSalaries = 0;
            Double MinSalaries = 0;

            EmployeeCount = ContactTable.Rows.Count;    
            TotalSalaris = Convert.ToDouble(ContactTable.Compute("Sum(Salaris)" , string.Empty));
            AverageSalaris = Convert.ToDouble(ContactTable.Compute("Avg(Salaris)" , string.Empty ));
            MaxSalaries = Convert.ToDouble(ContactTable.Compute("Max(Salaris)" , string.Empty ));
            MinSalaries = Convert.ToDouble(ContactTable.Compute("Min(Salaris)" , string.Empty )) ;   




            Console.WriteLine("\nList of the Contact Discription is ");
            foreach (DataRow row in ContactTable.Rows)
            {
                Console.WriteLine("ID : {0} \t Name : {1} \t Salaris : {2}", row[0] , row[1] , row[2]);

                //  Application.Run(new FrmMainWords());  
                

            }
            Console.WriteLine("\nTotal Employee is : "+ EmployeeCount); 
            Console.WriteLine("\nTotal Salaris : " + TotalSalaris);
            Console.WriteLine("\n Average :" + AverageSalaris);
            Console.WriteLine("\nMaximum" + MaxSalaries);   
            Console.WriteLine("\nManimum" + MinSalaries);

            Console.ReadKey();
        }
       
    }
}
