using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new int[] { 8, 5, 9, 2, 6, 3 };
            var sorted = InsertionSort(unsorted);
            Console.ReadKey();
        }

        public static int[] InsertionSort(int[] a)
        {
            for (int p = 1; p < a.Length; p++)
            {
                var tmp = a[p];
                int j = p;

                for (; j > 0 && tmp.CompareTo(a[j - 1]) < 0; j--)
                    a[j] = a[j - 1];
                a[j] = tmp;
            }

            return a;
        }
    }
}
