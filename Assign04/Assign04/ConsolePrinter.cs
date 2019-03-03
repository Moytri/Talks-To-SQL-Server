using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign04
{
    class ConsolePrinter
    {
        public static void PrintProvinces(List<string> provinces)
        {
            Console.WriteLine("Select province filter:");
            int itemNumber = 1;

            foreach(string province in provinces)
            {
                Console.WriteLine($"{itemNumber++,10}{": "}" + province);
            }
        }
    }
}
