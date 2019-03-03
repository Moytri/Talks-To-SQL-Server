﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign04
{
    class CustomerPrinter
    {
        static readonly string divider = new string('-', 70);

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
            Console.WriteLine($"\n{"CompanyName",-18}{" ",16}{"City",10}{" ", 8}{"Prov",4}{"Postal",8}{"Hold",6}");
            Console.WriteLine(divider);
        }
    }
}
