using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusniessWords
    {
        public int WordID {  get; set; }    
        public string Word {  get; set; }
        public string Translate { get; set; }
        public int WordTypeID { get; set; } 

        public clsBusniessWords() 
        { 
            this.WordID = -1;
            this.Word = "";
            this.Translate = ""; 
            this.WordTypeID = 1;    
        }
       

        //To Get all the data
        public static DataTable GetAllData()
        {
            return clsDataAccessWords.GetAllWords();
        }
        public bool _AddWords()
        {
            this.WordID = clsDataAccessWords.AddNewWord(this.Word , this.Translate , this.WordTypeID);
            if (this.WordID != -1)
            
                return true;
            
            else
            return false;
        }

    }
}
