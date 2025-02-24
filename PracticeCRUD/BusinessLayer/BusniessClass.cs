using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DataAccess; 

namespace BusinessLayer
{
    public class TryBusniess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TryBusniess(int id, string name)
        {

        Id = id;
       Name = name;
        }
        public static TryBusniess GetData1()
        {
            int TryID = 0;
            string TryName; 
           TryDataBase.getData(out TryID, out TryName);
            return new TryBusniess(TryID, TryName);
           

        }
        
    }
    public class clsCountry
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }    
        public string CountryInfo { get; set; }


       public clsCountry(  string countryName , int countryCode , string countryInfo)

        {
            CountryId = -1;
            CountryName = countryName;
            CountryCode = countryCode;
            CountryInfo = countryInfo;

        }

        public bool SaveCountryData()
        {
            this.CountryId = clsDataCountry.SaveCountryData(this.CountryName
                , this.CountryCode, this.CountryInfo);
            return (this.CountryId > -1);
        }


        /*  public clsCountry()
          {
              this.CountryId = -1;
              this.CountryName = ""; 
              this.CountryCode = 0;
              this.CountryInfo = ""; 
          }*/

        public static clsCountry GetAllDataCountry(int CId)
        {
             
            string CName ="";
            int CCode = 0;
            string CInfo = ""; 
            clsDataCountry.GetCoutryData( CId, ref CName , ref CCode , ref CInfo);   

            return new clsCountry( CName , CCode , CInfo);

        }

     


    }
    
    
}
