using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine(Root1(4));
            Console.WriteLine(Root2(4));

            Console.WriteLine(Root1(9));
            Console.WriteLine(Root2(9));

            Console.WriteLine(Root1(16));
            Console.WriteLine(Root2(16));

            Console.WriteLine(Root1(25));
            Console.WriteLine(Root2(25));

            Console.WriteLine(Root1(36));
            Console.WriteLine(Root2(36));

            Console.WriteLine(Root1(49));
            Console.WriteLine(Root2(49));*/

            /*for(var i = 1; i <= 100; i++)
            {
                Console.WriteLine(Root2(i));
            }*/

            /*for (var i = 1; i <= 100; i++)
            {
                Console.WriteLine(Root3(i, 6));
            }*/

            Root4(6.45m);

            Console.ReadKey();
        }

        static int Root1(int x)
        {
            var numberCount = 1;
            var currentVal = 1;
            while (currentVal < x)
            {
                currentVal = numberCount * numberCount;
                numberCount++;
            }
            return numberCount - 1;
        }

        static decimal Root2(decimal x)
        {
            decimal numberCount = x / 2;
            decimal currentVal = numberCount * numberCount;
            while (currentVal != x)
            {
                if (currentVal < x)
                {
                    numberCount += numberCount * 2;
                }
                else
                {
                    numberCount -= numberCount / 2;
                }

                currentVal = decimal.Round(numberCount * numberCount, 5, MidpointRounding.AwayFromZero);
            }

            numberCount = decimal.Round(numberCount, 6, MidpointRounding.AwayFromZero);

            return numberCount;
        }

        static decimal Root3(decimal x, int decimals = 4)
        {
            decimal number = decimal.Round(x / 2, decimals);
            decimal result = decimal.Round(x / number, decimals);
            decimal avg = decimal.Round(((number + result) / 2), decimals);

            while (avg != result)
            {
                number = decimal.Round(x / avg, decimals);
                result = decimal.Round(x / number, decimals);
                avg = decimal.Round((number + result) / 2, decimals);
                //Console.WriteLine(avg);
            }

            return avg;
        }

        static decimal Root4(decimal x, int decimals = 4)
        {
            var output = string.Empty;

            var xString = x.ToString();//string.Join(".", x.ToString());
            var xVal = decimal.Parse(xString);
            int firstDigit = int.Parse(xString.Substring(0, 1));
            decimal prevVal = 0;
            decimal firstVal = 2;
            int powerCount = 1;

            while(firstVal < firstDigit)
            {
                prevVal = firstVal;
                firstVal *= 2;
                powerCount++;
            }

            var current = xVal - prevVal;

            output += prevVal;

            return current;
        }
    }
}
