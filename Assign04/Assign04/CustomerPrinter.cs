using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign04
{
    class CustomerPrinter
    {
        static readonly string divider = new string('-', 80);

        public static void PrintProvinces(List<string> provinces)
        {
            Console.WriteLine("Select province filter:");
            int itemNumber = 1;

            foreach (string province in provinces)
            {
                Console.WriteLine($"{itemNumber++,10}{": "}" + province);
            }
        }

        public static void PrintCustomer(List<Customer> customers)
        {
            Console.WriteLine($"\n{"CompanyName",-40}{"City",-15}{"Prov",-6}{"Postal",-8}{"Hold",2}");
            Console.WriteLine(divider);

            foreach(Customer customer in customers)
            {
                Console.WriteLine($"{customer.CompanyName,-40}{customer.City,-15}{customer.Province,-6}{customer.PostalCode,-8}{(customer.CreditHold ? "Y" : "N"),2}");
            }
        }
    }
}
