using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._07._2024_Troitskaya_TelegrammBot
{
    public class CompanyData
    {
        public record Person(int id, string name, long inn);
        public class Program
        {
            Person company1 = new(1, "Davolio", 7731457980);
            Person compsny2 = new(2, "Davyyyyyyyyyolio", 1656541);

            
        }
        //Company company = new Company()
        /*class Company
        {
            public int id;
            public string name;
            public int inn;
        }

        public class NasledovanieCompany : CompanyData
        {
            private readonly List<Person> _people;
        }*/
    }
    
}
