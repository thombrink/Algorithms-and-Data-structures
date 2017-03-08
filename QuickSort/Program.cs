using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort {
    class Program {
        static void Main(string[] args) {
            var array1 = new int[] { 1, 8, 7, 10, 2, 4, 11, 3, 5, 6, 9 };
            var array2 = new int[] { 3, 5, 3, 8, 2, 1 };

            Console.WriteLine(QuickSort(array1));
            Console.WriteLine(QuickSort(array2));
            Console.ReadKey();
        }

        private static string QuickSort(int[] list, int start = 0, int end = -1) {
            end = end == -1 ? list.Length - 1 : end;

            if (start - end + 1 < 4) return string.Join(", ", InsertionSort.Program.InsertionSort(list));

            if (start == end) return string.Join(", ", list);

            int leftVal = list[start];
            int rightVal = list[end];
            int midVal = list[(end + 1) / 2];
            //int median = fistVal > midVal ? midVal > lastVal ? (end + 1) / 2 : fistVal > lastVal ? 0 : end : midVal > lastVal ? (end + 1) / 2 : end;

            int median, medianVal;
            if(leftVal > midVal && leftVal < rightVal) {
                median = start;
                medianVal = list[start];
            }
            else if(midVal > leftVal && midVal < rightVal) {
                median = (end + 1) / 2;
                medianVal = list[(end + 1) / 2];
            }
            else {
                median = end;
                medianVal = list[end];
            }

            // set the median val at the end
            list[median] = rightVal;
            list[end] = medianVal;

            // set the right val to the second last val because of the median
            rightVal = list[end - 1];

            // search the next values
            int i = start, j = end - 1;
            while (i < j) {
                while (leftVal < medianVal || rightVal > midVal) {
                    if (leftVal < medianVal) {
                        leftVal = list[++i];
                    }
                    if (rightVal > medianVal) {
                        rightVal = list[--j];
                    }
                }

                // swap the left end right index values
                list[i] = rightVal;
                list[j] = leftVal;

                if (i < j) {
                    leftVal = list[++i];
                    rightVal = list[--j];
                }
            }

            // swap the median val from the end to the left index
            list[i] = list[end];
            list[end] = rightVal;

            return QuickSort(list, start, i) + list[i] + QuickSort(list, i, end + 1);

            /*for(var i = 0; i < median; i++) {

            }

            for (var j = list.Length - 1; j > median; j--) {

            }*/

            //return QuickSort(list, 0, median) + median + QuickSort(list, median + 1, list.Length);
        }

        /*private static string QuickSort(int[] list, int start, int end) {
            if (list.Length < 4) return string.Join(", ", InsertionSort.Program.InsertionSort(list));

            int fistVal = list[0];
            int lastVal = list[list.Length - 1];
            int midVal = list[list.Length / 2];
            int median = fistVal > midVal ? midVal > lastVal ? list.Length / 2 : fistVal > lastVal ? 0 : list.Length - 1 : midVal > lastVal ? list.Length / 2 : list.Length - 1;

            return QuickSort(list, 0, median) + median + QuickSort(list, median + 1, list.Length);
        }*/
    }
}
