using System;
using System.Diagnostics;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            var n = 100000000;
            var nonPrimes = new bool[n];

            //The lonely even number
            Console.Write("2,");

            for (var i = 3; i < n; i += 2)
            {
                if (nonPrimes[i]) continue;

                Console.Write(i + ",");

                var nonPrime = i * 2;
                while (nonPrime < n)
                {
                    if (!nonPrimes[nonPrime])
                    {
                        nonPrimes[nonPrime] = true;
                    }
                    nonPrime = nonPrime + i;
                }

                //if (i % 3 == 0)
                //{
                //    primes.Add(i);
                //    //primes[i]++;
                //    Console.Write(i + ",");
                //}

                //for (var j = 2; j < i; j++)
                //{
                //    if (i % j == 0)
                //    {
                //        Console.WriteLine(i);
                //        break;
                //    }
                //}

                //    //Console.Write($"-- {i % primes[j]} {i} --");
                //    Console.WriteLine(primes[j] + "-" + i);

                //    //Console.Write(i + ",");
                //    //if (i % primes[j] == 1)
                //    //{
                //    //    primes.Add(i);
                //    //    //primes[i]++;
                //    //    Console.Write(i + ",");
                //    //    break;
                //    //}
                //}
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine(sw.Elapsed);
            sw.Stop();

            Console.ReadKey();
        }
    }
}
