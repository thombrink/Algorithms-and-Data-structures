using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();

            int min1 = 0;
            int max1 = 20000000;

            int min2 = 0;
            int max2 = 20000000;

            int min3 = 0;
            int max3 = 20000000;

            int[] array1 = new int[5000000];
            int[] array2 = new int[5000000];

            Random randNum = new Random();
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = randNum.Next(min1, max1 / (array1.Length - i));
                array2[i] = randNum.Next(min1, max2 / (array2.Length - i));

                min1 = array1[i];
                min2 = array2[i];
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            sw.Start();
            int[] result1 = Merge1(array1, array2);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            //Console.WriteLine(string.Join(",", result1));
            Console.Write(Environment.NewLine);

            int[] array3 = new int[10000000];

            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = randNum.Next(min3, max3 / (array3.Length - i));

                min3 = array3[i];
            }

            sw.Restart();
            int[] result2 = MergeSort(array3);
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
            //Console.WriteLine(string.Join(",", result2));
            Console.Write(Environment.NewLine);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            sw.Restart();
            var result3 = Merge2(array3, new int[array3.Length], 0, array3.Length, array3.Length - 1);
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
            //Console.WriteLine(string.Join(",", result3));
            Console.Write(Environment.NewLine);

            Console.ReadKey();
        }

        // the merge sort from lesson 1
        static T[] Merge1<T>(T[] arr1, T[] arr2) where T : IComparable
        {
            var newArr = new T[arr1.Length + arr2.Length];

            var arr1Index = 0;
            var arr2Index = 0;

            var arr1HadLastIndex = false;
            var arr2HadLastIndex = false;

            for (var i = 0; i < newArr.Length; i++)
            {
                var val1 = arr1[arr1Index];
                var val2 = arr2[arr2Index];

                if ((!arr1HadLastIndex && val1.CompareTo(val2) <= 0) || arr2HadLastIndex)
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

        public static T[] MergeSort<T>(T[] a) where T : IComparable
        {
            T[] tmpArray = new T[a.Length];
            return MergeSort(a, tmpArray, 0, a.Length - 1);
        }

        private static T[] MergeSort<T>(T[] a, T[] tmpArray, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int center = (left + right) / 2;
                MergeSort(a, tmpArray, left, center);
                MergeSort(a, tmpArray, center + 1, right);
                return Merge2(a, tmpArray, left, center + 1, right);
            }

            return new T[0];
        }

        private static T[] Merge2<T>(T[] a, T[] tmpArray, int leftPos, int rightPos, int rightEnd) where T: IComparable
        {
            int leftEnd = rightPos - 1;
            int tmpPos = leftPos;
            int numElements = rightEnd - leftPos + 1;

            // Main loop
            while (leftPos <= leftEnd && rightPos <= rightEnd)
                if (a[leftPos].CompareTo(a[rightPos]) <= 0)
                    tmpArray[tmpPos++] = a[leftPos++];
                else tmpArray[tmpPos++] = a[rightPos++];

            while (leftPos <= leftEnd)
                // Copy rest of first half
                tmpArray[tmpPos++] = a[leftPos++];

            while (rightPos <= rightEnd)
                // Copy rest of right half
                tmpArray[tmpPos++] = a[rightPos++];

            // Copy tmpArray back
            for (int i = 0; i < numElements; i++, rightEnd--)
                a[rightEnd] = tmpArray[rightEnd];

            return a;
        }
    }
}
