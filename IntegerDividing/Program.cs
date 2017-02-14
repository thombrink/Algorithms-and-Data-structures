using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerDividing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntegerDividing1(15, 5));
            //Console.WriteLine(IntegerDividing1(16789, 5));
            Console.WriteLine(IntegerDividing2(16789, 5));
            Console.WriteLine(IntegerDividing3(133, 4));

            Console.ReadKey();
        }

        static int IntegerDividing1(int x, int y)
        {
            var divideCount = 1;
            var currentVal = y;
            while(currentVal <= x)
            {
                currentVal += y;
                divideCount++;
            }
            return divideCount -1;
        }

        static int IntegerDividing2(int x, int y)
        {
            var divideCount = 20;
            var currentVal = y * divideCount;
            //var belowX = false;
            //var aboveX = false;

            while (currentVal != x)//&& (!belowX || !aboveX)
            {
                if (currentVal < x)
                {
                    divideCount += divideCount * 2;
                    //aboveX = true;
                }
                else
                {
                    divideCount -= divideCount / 2;
                    //belowX = true;
                }
                currentVal = y * divideCount;
                //divideCount++;
                if(currentVal < x && currentVal + y > x)
                {
                    currentVal = x;
                    //divideCount++;
                }
            }
            //if (currentVal == x) divideCount--;
            return divideCount;
        }

        static int IntegerDividing3(int x, int y)
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine($"{x} / {y}");

            //var test = Math.Floor(Math.Log10(x) + 1);
            var intString = x.ToString();
            var even = intString.Length % 2 == 0;
            var rest = 0;
            string output = string.Empty;
            for (var i = 0; i < intString.Length; i+=2)
            {
                var divideCount = 1;
                string subString = rest > 0 ? rest.ToString() : string.Empty;
                if(!even && i == intString.Length - 1)
                {
                    subString += x.ToString().Substring(i, 1);
                } else
                {
                    subString += x.ToString().Substring(i, 2);
                }

                var startValue = int.Parse(subString);
                var currentVal = y;
                while (startValue > currentVal)
                {
                    currentVal += y;
                    divideCount++;
                }

                if (startValue != currentVal)
                {
                    divideCount--;
                }

                rest = startValue - (currentVal - y);
                output += divideCount.ToString();

                Console.WriteLine(output);
            }
            return int.Parse(output);
        }
    }
}
