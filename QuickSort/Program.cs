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

            var array3 = new int[] { 5, 4, 3, 2, 1 };
            var array4 = new int[] { 4, 3, 2, 1, 5 };
            var array5 = new int[] { 3, 2, 1, 5, 4 };
            var array6 = new int[] { 2, 1, 5, 4, 3 };
            var array7 = new int[] { 1, 5, 4, 3, 2 };
            var array8 = new int[] { 1, 2, 3, 4, 5 };

            var array9 = new int[] { 4, 10, 5, 2, 9, 8, 1, 7, 3, 6 };

            //Console.WriteLine(QuickSort(array1));
            //Console.WriteLine(QuickSort(array2));

            //Console.WriteLine(QuickSort(array3));
            //Console.WriteLine(QuickSort(array4));
            //Console.WriteLine(QuickSort(array5));
            //Console.WriteLine(QuickSort(array6));
            //Console.WriteLine(QuickSort(array7));
            //Console.WriteLine(QuickSort(array8));

            //Console.WriteLine(QuickSort(array9));

            //QuickSortRecursive(array9);
            //Quicksort(array9);

            var random = new Random();

            for (var i = 0; i < 1000; i++) {
                var testArr = new int[10];

                for (var j = 0; j < 10; j++) {
                    //var nextVal = random.Next(0, 10);
                    int nextVal;

                    while (testArr.Contains(nextVal = random.Next(0, 11))) {
                    }

                    testArr[j] = nextVal;
                }

                QuickSort(testArr);
                var result = string.Join(", ", testArr);
                if (result != "1, 2, 3, 4, 5, 6, 7, 8, 9, 10") {
                    Console.WriteLine("test " + i + ": " + result);
                }
            }

            Console.WriteLine("Kloar!");

            Console.ReadKey();
        }

        //private static string QuickSort(int[] list, int start = 0, int end = -1) {
        //    end = end == -1 ? list.Length - 1 : end;

        //    if (end - start < 4) {
        //        var newArr = InsertionSort.Program.InsertionSort(list);// start, end

        //        var result = new StringBuilder();

        //        for (int k = start; k <= end; k++) {
        //            result.Append( newArr[k] + ", ");
        //        }

        //        return result.ToString();
        //    }

        //    if (start == end) {
        //        var result = new StringBuilder(); 

        //        for(int k = start; k < end; k++) {
        //            result.Append(list[k] + ", ");
        //        }

        //        return result.ToString();
        //    }

        //    int leftVal = list[start];
        //    int rightVal = list[end];
        //    int midVal = list[(end + 1) / 2];

        //    Console.Write($"{leftVal} {midVal} {rightVal}");

        //    int median, medianVal;
        //    if( leftVal >= midVal && leftVal <= rightVal || leftVal <= midVal && leftVal >= rightVal) {
        //        median = start;
        //        medianVal = list[start];
        //    }
        //    else if(midVal >= leftVal && midVal <= rightVal || midVal <= leftVal && midVal >= rightVal) {
        //        median = (end + 1) / 2;
        //        medianVal = list[(end + 1) / 2];
        //    }
        //    else {
        //        median = end;
        //        medianVal = list[end];
        //    }

        //    Console.Write($" ==> {medianVal}" + Environment.NewLine);

        //    // set the median val at the end
        //    list[median] = rightVal;
        //    list[end] = medianVal;

        //    // set the right val to the second last val because of the median
        //    leftVal = list[start];
        //    rightVal = list[end - 1];

        //    // search the next values
        //    int i = start, j = end - 1;
        //    while (i < j) {
        //        while ((leftVal < medianVal || rightVal > medianVal) && i < j) {
        //            if (leftVal < medianVal) {
        //                leftVal = list[++i];
        //            }
        //            if (rightVal > medianVal) {
        //                rightVal = list[--j];
        //            }
        //        }

        //        // swap the left end right index values
        //        list[i] = rightVal;
        //        list[j] = leftVal;

        //        if (i < j) {
        //            leftVal = list[++i];
        //            rightVal = list[--j];
        //        }
        //    }

        //    // swap the median val from the end to the left index
        //    list[end] = list[i];
        //    list[i] = medianVal;

        //    return QuickSort(list, start, j - 1) + list[i] + ", " + QuickSort(list, i + 1, end);

        //    /*for(var i = 0; i < median; i++) {

        //    }

        //    for (var j = list.Length - 1; j > median; j--) {

        //    }*/

        //    //return QuickSort(list, 0, median) + median + QuickSort(list, median + 1, list.Length);
        //}

        /*private static string QuickSort(int[] list, int start, int end) {
            if (list.Length < 4) return string.Join(", ", InsertionSort.Program.InsertionSort(list));

            int fistVal = list[0];
            int lastVal = list[list.Length - 1];
            int midVal = list[list.Length / 2];
            int median = fistVal > midVal ? midVal > lastVal ? list.Length / 2 : fistVal > lastVal ? 0 : list.Length - 1 : midVal > lastVal ? list.Length / 2 : list.Length - 1;

            return QuickSort(list, 0, median) + median + QuickSort(list, median + 1, list.Length);
        }*/

        static public int Partition(int[] numbers, int left, int right) {
            int pivot = numbers[left];
            while (true) {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right) {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else {
                    return right;
                }
            }
        }

        static public void QuickSortRecursive(int[] arr, int left = 0, int right = -1) {
            right = right == -1 ? arr.Length - 1 : right;

            if (left < right) {
                if (right - left < 4) {
                    InsertionSort.Program.InsertionSort(arr, left, right);
                }
                else {
                    int pivot = Partition(arr, left, right);

                    if (pivot > 1)
                        QuickSortRecursive(arr, left, pivot - 1);

                    if (pivot + 1 < right)
                        QuickSortRecursive(arr, pivot + 1, right);
                }
            }
        }

        public static void SwapReferences<T>(T[] a, int index1, int index2) {
            T tmp = a[index1];
            a[index1] = a[index2];
            a[index2] = tmp;
        }

        public static void QuickSort<T>(T[] a) where T : IComparable {
            QuickSort(a, 0, a.Length - 1);
        }

        private static void QuickSort<T>(T[] a, int low, int high) where T : IComparable {
            if (low + 3 > high) InsertionSort.Program.InsertionSort(a, low, high);
            else {
                // Sort low, middle, high
                int middle = (low + high) / 2;
                if (a[middle].CompareTo(a[low]) < 0)
                    SwapReferences(a, low, middle);

                if (a[high].CompareTo(a[low]) < 0)
                    SwapReferences(a, low, high);

                if (a[high].CompareTo(a[middle]) < 0)
                    SwapReferences(a, middle, high);

                // Place pivot at position high - 1
                SwapReferences(a, middle, high - 1);

                T pivot = a[high - 1];

                // Begin partitioning
                int i, j;

                for (i = low, j = high - 1; ;) {
                    while (a[++i].CompareTo(pivot) < 0) ;
                    while (pivot.CompareTo(a[--j]) < 0) ;

                    if (i >= j) break;

                    SwapReferences(a, i, j);
                }

                // Restore pivot
                SwapReferences(a, i, high - 1);
                QuickSort(a, low, i - 1);    // Sort small elements
                QuickSort(a, i + 1, high);   // Sort large elements
            }
        }
    }
}
