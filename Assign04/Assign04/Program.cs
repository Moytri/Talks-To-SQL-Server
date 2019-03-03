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

            CustomerPrinter.PrintProvinces(provinces);

            string provinceInput = Console.ReadLine();
            bool sucess = int.TryParse(provinceInput, out int filter);

            if(!sucess)
            {
                return;
            }

            string selectedProvince = provinces[--filter];

            Console.WriteLine(selectedProvince);
        }
    }
}
