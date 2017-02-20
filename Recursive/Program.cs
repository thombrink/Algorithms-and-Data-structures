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

            Console.ReadKey();
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
