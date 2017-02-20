using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine(Convert.ToString(2147483647, 2));

            for(var i = 0; i <= 18; i++)
            {
                Console.WriteLine(i + " = " + Convert.ToString(i, 2) + " | " + Convert.ToString(1 << i) + " = " + Convert.ToString(1 << i, 2));
            }*/

            var integer = int.Parse(Console.ReadLine());

            Console.WriteLine("het quadraat van " + integer + " is " + (integer << 3));
            Console.WriteLine("de wortel van " + integer + " is " + (integer >> 3));

            Console.ReadKey();
        }
    }
}
