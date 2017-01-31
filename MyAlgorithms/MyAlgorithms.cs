using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmsLib
{
    public class MyAlgorithms
    {
        //static T[] CreateRandomArray<T>(int length, double min, double max) where T : struct
        //{
        //    var random = new Random();
        //    var arr = new T[length];
        //    for (var i = 0; i < length; i++)
        //    {
        //        arr[i] = (T)(random.NextDouble() * (max - min) + min);
        //    }
        //    return arr;
        //}

        public static int[] CreateRandomIntArray(int length, int min, int max)
        {
            var random = new Random();
            var arr = new int[length];
            for (var i = 0; i < length; i++)
            {
                arr[i] = random.Next(min, max) * (max - min) + min;
            }
            return arr;
        }

        public static double[] CreateRandomDoubleArray(int length, double min, double max)
        {
            var random = new Random();
            var arr = new double[length];
            for (var i = 0; i < length; i++)
            {
                arr[i] = random.NextDouble() * (max - min) + min;
            }
            return arr;
        }

        public static int GetMaxIndex(double[] array)
        {
            //array.Max();

            var maxIndex = 0;
            for(var i = 0; i < array.Length; i++) {
                if(i < array.Length -1 && array[i+1] > array[i])
                {
                    maxIndex = i + 1;
                }
            }
            
            return maxIndex;
        }

        public static double GetMax(double[] array)
        {
            return array[GetMaxIndex(array)];
        }

        public static int CumulatieveSum(int[] array, int index)
        {
            var currentSum = 0;
            for (var i = 0; i < index + 1; i++)
            {
                currentSum += array[i];
            }

            return currentSum;
        }

        public static int CumulatieveSumv2(int[] array, int index)
        {
            return array[index];
        }

        public static int[] CumulatieveSumv2Init(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                array[i] += array[i - 1];
            }
            return array;
        }
    }
}
