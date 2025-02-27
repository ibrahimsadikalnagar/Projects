using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DataAccess; 

namespace BusinessLayer
{
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
            Mode = EMode.AddMode;
        }

        private AddBusnissCountryLayer(int iD, string name, int countryCode, string countryInfo)
        {
            ID = iD;
            Name = name;
            CountryCode = countryCode;
            CountryInfo = countryInfo;
            Mode = EMode.UpdateMode;
        }

        public static AddBusnissCountryLayer FindData(int ID)
        {
            string name1 = "", countryInfo1 ="";
            int countryCode1 = 0;
            if (clsDataAccess.FindDataByID(ID, ref name1, ref countryCode1, ref countryInfo1))
            {
                return new AddBusnissCountryLayer(ID, name1, countryCode1, countryInfo1);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewCountry()
        {
            this.ID = clsDataAccess.AddNewData(Name ,CountryCode, CountryInfo);
            return (this.ID != -1);
        }

        private bool _UpdateData()
        {
            return clsDataAccess.UpdateData(this.ID , this.Name , this.CountryCode , this.CountryInfo); 
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

                    return _UpdateData();
            }
            return false;

        }

    }
    
    
}
