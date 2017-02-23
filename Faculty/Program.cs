using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty
{
    class Program
    {
        static void Main(string[] args)
        {
            Recursive(20);
            NonRecursive(20);

            Console.ReadKey();
        }

        static long Recursive(int times)
        {
            if(times == 1)
            {
                Console.WriteLine("1");
                return 1;
            }

            var val = Recursive(times -1);

            Console.WriteLine(times * val);

            return times * val;
        }

        static void NonRecursive(int times)
        {
            long val = 1;
            for(var i = 1; i < times; i++)
            {
                val = i * val;
                Console.WriteLine(val);  
            }
        }
    }
}
