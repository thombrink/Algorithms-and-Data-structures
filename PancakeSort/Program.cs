﻿using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSort {
    class Program {
        static void Main(string[] args) {
            var dlist = new DoublyLinkedList<int>();  
            dlist.Add(5);
            dlist.Add(2);
            dlist.Add(6);
            dlist.Add(4);
            dlist.Add(3);         
            dlist.Add(1);

            Console.WriteLine("-" + dlist.ToString());

            dlist = PancakeSort(dlist);

            Console.WriteLine("-" + dlist.ToString());

            Console.ReadKey();
        }

        private static DoublyLinkedList<int> PancakeSort(DoublyLinkedList<int> list) {
            for (var i = list.Length - 1; i > 0; i--) {
                var maxValIndex = list.GetMaxValueIndex(i);
                list.Flip(maxValIndex);
                Console.WriteLine("--" + list.ToString() + " fliped row until max val at index " + maxValIndex);
                list.Flip(i);
                Console.WriteLine("--" + list.ToString() + " fliped row");
            }

            return list;
        }
    }
}
