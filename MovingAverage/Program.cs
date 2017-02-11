using LinkedList;
using System;

namespace MovingAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var input = new double[] { 4, 5, 3, 2, 1, 1, 4, 8, 10, 12, 15, 18, 20 };
            var total = 0d;

            //array
            Console.WriteLine("normal array implementation");
            for (int i = 0; i < input.Length; i++)
            {
                total += input[i];

                if(i < n)
                {
                    Console.Write(total / (i + 1) + " ");
                }
                else
                {
                    total -= input[i - n];
                    Console.Write(total / n + " ");
                }
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine("linkedlist implementation");

            //set up the linked list example
            var linkedList = new SinglyLinkedList<double>();
            for (int i = 0; i < input.Length; i++)
            {
                linkedList.Add(input[i]);
            }

            linkedList.PrintMovingAverage(4);

            Console.ReadKey();
        }
    }
}
