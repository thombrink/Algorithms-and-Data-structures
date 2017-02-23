using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var val1 = Recursive(20, true);
            sw.Stop();

            Console.WriteLine(val1 + " calculated in " + sw.Elapsed);

            Console.WriteLine("Press any key to test the non recursive version :)");
            Console.ReadKey();
            Console.Write(Environment.NewLine);

            sw.Restart();
            var val2 = NonRecursive(20, true);
            sw.Stop();

            Console.WriteLine(val2 + " calculated in " + sw.Elapsed);

            Console.ReadKey();
        }

        static long Recursive(int times, bool showCpuInstructions)
        {
            if (times <= 1)
            {
                if(showCpuInstructions) Console.WriteLine("1");
                return 1;
            }

            var prevVal = Recursive(times - 2, showCpuInstructions);
            var val = Recursive(times - 1, showCpuInstructions);

            if (showCpuInstructions) Console.WriteLine(prevVal + val);

            return prevVal + val;
        }

        static long NonRecursive(int times, bool showCpuInstructions)
        {
            long val = 1;
            long prevVal = 1;
            for (var i = 1; i < times; i++)
            {
                var newVal = val + prevVal;
                prevVal = val;
                val = newVal;

                if (showCpuInstructions) Console.WriteLine(val);
            }

            return val;
        }
    }
}
