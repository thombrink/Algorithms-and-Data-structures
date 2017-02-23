using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1DArray1 = new int[] { 1, 3, 5, 1, 1, 10, 6, 8, 3, 6 };
            var result2DArray1 = Pixels1DTo2D(test1DArray1);
            var result1DArray1 = Pixels2DTo1D(result2DArray1);

            var result2DArray2 = Pixels1DTo2DImproved(test1DArray1);
            var result1DArray2 = Pixels2DTo1DImproved(result2DArray2);

            //int nearestX, nearestY;
            //FindNearest(result2DArray1, 10, 1, out nearestX, out nearestY);
            var nearestPoint = FindNearest(result2DArray1, 10, 1);

            var max = GetMaxRecursive(test1DArray1);

            Console.ReadKey();
        }

        static int[][] Pixels1DTo2D(int[] pixels1d, int width = 2)
        {
            var heigth = pixels1d.Length / width;
            var array2D = new int[heigth][];

            /*var currPixel = 0;
            for (var y = 0; y < heigth; y++)
            {
                var arrayX = new int[width];
                //array2D[y] = arrayX;
                for (var x = 0; x < width; x++)
                {
                    //array2D[y][x] = pixels1d[currPixel++];
                    arrayX[x] = pixels1d[currPixel++];
                }
                array2D[y] = arrayX;
            }*/

            int currentY = -1;
            for(var i = 0; i < pixels1d.Length; i++)
            {
                var index = i % width;
                if(index == 0)
                {
                    array2D[++currentY] = new int[width];
                }

                array2D[currentY][index] = pixels1d[i];
            }

            return array2D;
        }

        static int[,] Pixels1DTo2DImproved(int[] pixels1d, int width = 2)
        {
            var heigth = pixels1d.Length / width;
            var array2D = new int[heigth, width];

            int currentY = -1;
            for (var i = 0; i < pixels1d.Length; i++)
            {
                var index = i % width;
                if (index == 0)
                {
                    currentY++;
                }

                array2D[currentY, index] = pixels1d[i];
            }

            return array2D;
        }

        static int[] Pixels2DTo1D(int[][] pixels2d)
        {
            var width = pixels2d[0].Length;
            var array1D = new int[pixels2d.Length * width];
            int currentIndex = 0;
            for (var y = 0; y < pixels2d.Length; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    array1D[currentIndex++] = pixels2d[y][x];
                }
            }

            return array1D;
        }

        static int[] Pixels2DTo1DImproved(int[,] pixels2d)
        {
            var array1D = new int[pixels2d.Length];

            int index = 0;
            foreach (var i in pixels2d)
            {
                array1D[index++] = i;
            }

            return array1D;
        }

        static Point FindNearest(int[][] coords, int pointX, int pointY)
        {
            int currentDiff = int.MaxValue;
            var nearestPoint = new Point();

            for (var i = 0; i < coords.Length; i++)
            {
                var x = coords[i][0];
                var y = coords[i][1];

                var diffX = pointX - x;
                var diffY = pointY - y;

                if (diffX < 0) diffX = diffX * -1;
                if (diffY < 0) diffY = diffY * -1;

                var newDiff = diffX + diffY;
                if (newDiff < currentDiff)
                {
                    currentDiff = newDiff;
                    nearestPoint.X = x;
                    nearestPoint.Y = y;
                    //nearestX = x;
                    //nearestY = y;

                    if (newDiff == 0) break;
                }
            }

            return nearestPoint;
        }

        static int GetMaxRecursive(int[] array)
        {
            if (array.Length == 0) return 0;

            var maxVal = array[array.Length - 1];

            var newArray = new int[array.Length - 1];
            Array.Copy(array, newArray, newArray.Length);            

            var newVal = GetMaxRecursive(newArray);

            if (((IComparable)newVal).CompareTo(maxVal) > 0)
            {
                maxVal = newVal;
            }

            return maxVal;
        }
    }
}
