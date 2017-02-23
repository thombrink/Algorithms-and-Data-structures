using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var dlist = new DoublyLinkedList<int>();
            dlist.Add(6);
            dlist.Add(5);
            dlist.Add(4);
            dlist.Add(3);
            dlist.Add(2);
            dlist.Add(1);

            dlist = PancakeSort(dlist);

            var currentDItem = dlist.First;
            while (currentDItem != null)
            {
                Console.WriteLine(currentDItem.Data);

                currentDItem = currentDItem.Next;
            }

            Console.ReadKey();
        }

        private static DoublyLinkedList<int> PancakeSort(DoublyLinkedList<int> list)
        {
            //for (var i = list.Length - 1; i > 0; i--)
            //{
                //list.Flip(list.GetMaxValueIndex(i));
                //list.Flip(i);
            //}

            list.Flip(list.Length);

            return list;
        }
    }
}
