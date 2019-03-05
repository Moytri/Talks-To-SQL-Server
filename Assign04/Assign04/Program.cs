using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> provinces = CustomerRepository.GetDistinctProvinces();
            Console.Title = "COMP2614 - Assignment 4 - A01062206";

            CustomerPrinter.PrintProvinces(provinces);

            string provinceInput = Console.ReadLine();
            bool sucess = int.TryParse(provinceInput, out int filter);

            //return from the method for provinceName (e.g: BC) as user input instead of item number (e.g: 2)
            if(!sucess)
            {
                return;
            }

            //get selected province name for the given input
            string selectedProvince = provinces[--filter];
            Console.WriteLine("Customer listing for " + selectedProvince);
            
            List<Customer> customers = CustomerRepository.GetCustomersByProvince(selectedProvince);
            CustomerPrinter.PrintCustomer(customers);

        }
    }
}
