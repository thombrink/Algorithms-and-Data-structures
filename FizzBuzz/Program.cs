using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var i = 1; i < 99; i++)
            {
                Console.Write(i % 3 == 0 ? i % 5 == 0 ? "FizzBuzz," : "Fizz," : i % 5 == 0 ? "Buzz," : i + ", ");

                //var multipleOfThree = i % 3 == 0;
                //var multipleOfFive = i % 5 == 0;
                //if(multipleOfThree && multipleOfFive)
                //{
                //    Console.Write("FizzBuzz,");
                //}
                //else if (multipleOfThree)
                //{
                //    Console.Write("Fizz,");
                //}
                //else if (multipleOfFive)
                //{
                //    Console.Write("Buzz,");
                //}
                //else
                //{
                //    Console.Write(i + ",");
                //}
            }

            Console.ReadKey();
        }
    }
}
