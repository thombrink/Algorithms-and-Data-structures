using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var input = new double[] { 4, 5, 3, 2, 1, 1, 4, 8, 10, 12, 15, 18, 20 };
            var total = 0d;

            for(int i = 0; i < input.Length; i++)
            {
                total += input[i];

                if(i < n)
                {
                    Console.Write(total / (i + 1) + " ");
                }
                else
                {
                    total -= input[i - n];
                    Console.Write(total / n + " ");
                }
            }

            Console.ReadKey();
        }
    }
}
