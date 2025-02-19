using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBusinessLayers; 

namespace _3TierArchiteture
{
    internal class Program
    {
        static void testFindContact(int ID)
        {

            clsContact contact = clsContact.Find(ID);
            if (contact != null)
            {

                Console.WriteLine(contact.FirstName + " " + contact.LastName);
                Console.WriteLine(contact.Email);
                Console.WriteLine(contact.Phone);
                Console.WriteLine(contact.Address);
                Console.WriteLine(contact.DateOfBirth);
                Console.WriteLine(contact.CountryID);
                Console.WriteLine(contact.ImagePath);
                Console.WriteLine(contact.ID);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");
            }
          

        }
      

       
        static void Main(string[] args)
        {
           testFindContact(2); 
           
            
            Console.ReadKey();
        }
    }
}
