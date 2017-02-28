using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            PrintForward1(list, 3);
            Console.Write(Environment.NewLine);
            PrintBackward1(list, 3);

            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

            list = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            PrintForward2(list, 3);
            Console.Write(Environment.NewLine);
            list = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            PrintBackward2(list, 3);

            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

            Console.WriteLine(SumOddOrEven(5));
            Console.WriteLine(SumOddOrEven(6));
            Console.WriteLine(SumOddOrEven(7));

            Console.Write(Environment.NewLine);

            Console.WriteLine(BinaryOnes(22));
            Console.WriteLine(BinaryOnes(9));
            Console.WriteLine(BinaryOnes(7));

            Console.ReadKey();
        }

        //http://math.stackexchange.com/questions/86207/converting-decimalbase-10-numbers-to-binary-by-repeatedly-dividing-by-2
        private static int BinaryOnes(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            var rest = (n % 2 == 0 ? 0 : 1);

            return BinaryOnes(n / 2) + rest;
        }

        private static int SumOddOrEven(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            return SumOddOrEven(n - 2) + n;

        }

        static void PrintForward1(List<int> theList, int i)
        {
            if (i < theList.Count)
            {
                Console.Write(theList[i] + ", ");
                PrintForward1(theList, i + 1);
            }
        }

        static void PrintForward2(List<int> theList, int i)
        {
            if (i != theList.Count)
            {
                Console.Write(theList[i] + ", ");
                theList.RemoveAt(i);
                PrintForward2(theList, i);
            }
        }

        static void PrintBackward1(List<int> theList, int i)
        {
            if (i < theList.Count)
            {
                PrintBackward1(theList, i + 1);
                Console.Write(theList[i] + ", ");
            }
        }

        static void PrintBackward2(List<int> theList, int i)
        {
            if (i != theList.Count)
            {
                Console.Write(theList[theList.Count - 1] + ", ");
                theList.RemoveAt(theList.Count - 1);
                PrintBackward1(theList, i);
            }
        }
    }
}
