using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

using MyAlgorithmsLib;


namespace ExperimentalComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest(100000);
            RunTest(1000000);
            RunTest(10000000);
            //RunTest(100000000);
            Console.ReadKey();
        }

        static void RunTest(int arrayLength)
        {
            var processTimes = new List<TimeSpan>();
            var sw = new Stopwatch();

            sw.Start();
            for (var i = 0; i < 5; i++)
            {
                var arr = MyAlgorithms.CreateRandomDoubleArray(arrayLength, 0, 200);
                MyAlgorithms.GetMax(arr);
                processTimes.Add(sw.Elapsed);
                sw.Restart();
            }
            sw.Stop();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine(processTimes.Average(x => x.TotalSeconds) + " - " + arrayLength);
        }
    }
}
