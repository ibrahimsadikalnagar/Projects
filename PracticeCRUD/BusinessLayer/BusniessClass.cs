using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DataAccess; 

namespace BusinessLayer
{
  
       public class clsAddCountry
    {
        public string  CountryName { get; set; }
        public int CountryCode { get; set; }
        public string CountryInfo { get; set; } 

        

        public clsAddCountry()
        { 
            
        }
        public static  bool AddCountry(clsAddCountry C)
        {
            return clsDataAccess.AddData(C.CountryName , C.CountryCode , C.CountryInfo);
        }
        
    }
    public class AddBusnissCountryLayer
    {
        enum EMode { AddMode = 0, UpdateMode = 1 }
        EMode Mode = EMode.AddMode;
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public string CountryInfo { get; set; }

        public AddBusnissCountryLayer()
        {
            this.ID = 0;
            this.Name = "";
            this.CountryCode = 0;
            this.CountryInfo = "";
        }

        private AddBusnissCountryLayer(int iD, string name, int countryCode, string countryInfo)
        {
            ID = iD;
            Name = name;
            CountryCode = countryCode;
            CountryInfo = countryInfo;
        }
        private bool _AddNewCountry()
        {
            this.ID = clsDataAccess.AddNewData(Name ,CountryCode, CountryInfo);
            return (this.ID != -1);
        }

        public bool save()
        {
            switch (Mode)
            {
                case EMode.AddMode:
                    if (_AddNewCountry())
                    {
                        Mode = EMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EMode.UpdateMode:

                    return _AddNewCountry();
            }
            return false;

        }

    }
    
    
}
