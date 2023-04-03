using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Library
{
    public class Services
    {
        public static int ListSelect<T>(List<T> values, int option) // 0 = no choice // 1 = choice
        {
            int i = 1;
            foreach (var value in values)
            {
                Console.Write(i + ": ");
                Console.WriteLine(value);
                i++;
            }
            if (option == 1 && values.Count != 0)
            {
                string choice = Console.ReadLine() ?? string.Empty;
                Console.Clear();
                return int.Parse(choice) - 1; // return choice
            }
            return 0;
        }





    }
}
