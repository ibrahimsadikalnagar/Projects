using System;
using System.Collections.Generic;
using System.Linq;
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
            string TryName = ""; 
           TryDataBase.getData(ref TryID, ref TryName);
            return new TryBusniess(TryID, TryName);
           

        }


    

    }
    
}
