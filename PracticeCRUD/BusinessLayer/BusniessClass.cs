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
    
    
}
