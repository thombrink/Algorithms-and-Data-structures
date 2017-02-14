using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArray1 = new int[] { 1, 3, 5, 1, 1, 10, 6, 8, 3, 6 };
            var testArray2 = testArray1.OrderBy(x => x).ToArray();

            LineairSearch(6, testArray1);
            LineairSearch(6, testArray2);

            //BinarySearch(6, testArray1);
            BinarySearch(6, testArray2);

            Console.ReadKey();
        }

        static int LineairSearch(int number, int[] array) {
            var index = -1;
            for(var i = 0; i < array.Length; i++)
            {
                if (i == number)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static int BinarySearch(int number, int[] sortedArray)
        {
            var currentIndex = (sortedArray.Length -1) / 2; 
            var currentVal = sortedArray[currentIndex];
            while(currentVal != number)
            {
                if(currentVal < number)
                {
                    currentIndex += currentIndex / 2;
                }
                else
                {
                    currentIndex -= currentIndex / 2;
                }
                currentVal = sortedArray[currentIndex];
            }
            return currentIndex;
        }
    }
}
