using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 5, 10, 11 };
            int[] array2 = { 0, 2, 3, 5, 6, 7, 12 };
            int[] result = Merge(array1, array2);

            Console.WriteLine(string.Join(",", result));
            Console.ReadKey();
        }

        static T[] Merge<T>(T[] arr1, T[] arr2) where T : struct
        {
            var newArr = new T[arr1.Length + arr2.Length];

            var arr1Index = 0;
            var arr2Index = 0;

            var arr1HadLastIndex = false;
            var arr2HadLastIndex = false;

            for (var i = 0; i < newArr.Length; i++)
            {
                dynamic val1 = arr1[arr1Index];
                dynamic val2 = arr2[arr2Index];

                if ((!arr1HadLastIndex && val1 < val2) || arr2HadLastIndex)
                {
                    newArr[i] = val1;

                    if (arr1Index == arr1.Length - 1)
                    {
                        arr1HadLastIndex = true;
                    }
                    else
                    {
                        arr1Index++;
                    }
                }
                else
                {
                    newArr[i] = val2;

                    if (arr2Index == arr2.Length - 1)
                    {
                        arr2HadLastIndex = true;
                    }
                    else
                    {
                        arr2Index++;
                    }
                }
            }

            return newArr;
        }
    }
}
