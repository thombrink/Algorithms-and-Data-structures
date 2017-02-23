using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Resursive(10));
            Console.WriteLine(NonResursive(10));
            Console.WriteLine(NonResursive(10, 5));

            Console.ReadKey();
        }

        static int Resursive(int x)
        {
            if (x == 1) return 0;
            return 1 + Resursive(x / 2);
        }

        static int NonResursive(int x, int n = 2)
        {
            var count = 0;
            while (x > 1)
            {
                x /= n;
                count++;
            }
            return count;
        }
    }
}
