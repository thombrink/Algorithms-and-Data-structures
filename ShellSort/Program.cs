using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new int[] { 8, 5, 9, 2, 6, 3 };
            var sorted = Shellsort(unsorted);
            Console.ReadKey();
        }

        static int[] Shellsort(int[] a)
        {
            for (int gap = a.Length / 2; gap > 0; gap = gap == 2 ? 1 : (int) (gap / 2.2 ) )
                for (int i = gap; i < a.Length; i++ ) {
                    var tmp = a[i];
                    int j = i;

                    for ( ; j >= gap && tmp.CompareTo(a[j - gap] ) < 0; j -= gap )
                        a[j] = a[j - gap];
                    a[j] = tmp;
                }

            return a;
        }
    }
}
