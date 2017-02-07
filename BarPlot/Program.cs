using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarPlot
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 9, 8, 4, 3, 8, 1, 1, 2, 8, 2,
                          1, 6, 0, 9, 8, 7, 0, 7, 3, 2 };
            int[] bins = new int[] { 0, 3, 6, 9, 12 };
            /*  
            categorie 0 is van 0 (inclusief) tot 3 (exclusief 3, dus niet meegeteld). Categorie 1 is van 3 (inclusief) tot 6 (exclusief), etc.. 
            */
            int[] barPlot = CreateBarPlot(array, bins);
            // histogram = { 8, 3, 7, 2 }.  
            // Er zijn 8 waarden tussen de 0 (inclusief) en 3 (exclusief).

            Console.WriteLine(string.Join(",", barPlot));
            Console.ReadKey();
        }

        static T[] CreateBarPlot<T>(T[] array, T[] bins) where T : struct
        {
            var bars = new T[bins.Length - 1];

            dynamic prevBin = 0;
            for (var g = 1; g < bins.Length; g++)
            {
                dynamic nextBin = bins[g];

                for (var n = 0; n < array.Length; n++)
                {
                    if (array[n] >= prevBin && array[n] < nextBin)
                    {
                        bars[g - 1] = (dynamic)bars[g - 1] + 1;
                    }
                }

                prevBin = bins[g];
            }
            return bars;
        }

        static int[] CreateBarPlot(int[] array, int[] bins)
        {
            var min = array.Min();
            var max = array.Max();
            //var bars1 = new int[max - min];
            var bars1 = new int[max - min + 1];
            var bars2 = new int[bins.Length - 1];

            for (var n = 0; n < array.Length; n++)
            {
                var val = array[n];
                //bars1[array[n] - min - (val == min ? 0 : 1)]++;
                bars1[array[n] - min]++;
            }

            int curBin = 0;
            int curMax = bins[1];
            for (var b = 0; b < bars1.Length; b++)
            {
                if (b + min > curMax - 1 && curBin < bins.Length - 1)
                {
                    curBin++;
                    curMax = bins[curBin + 1];
                }

                bars2[curBin] += bars1[b];
            }

            return bars2;
        }
    }
}
