using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var slist = new SinglyLinkedList<int>();
            //slist.Add(1);
            //slist.Add(2);
            //slist.Insert(2, 2);
            //slist.Insert(2, 5);
            //slist.Remove(2);
            //slist.Insert(2, 3);

            slist.Add(0);
            slist.Add(1);
            slist.Add(2);
            Console.WriteLine("get index 1: " + slist.Get(1));
            //slist.Remove(2);
            //slist.Get(1);
            //slist.Remove(1);
            //slist.Get(0);
            //slist.Remove(0);

            var currentSItem = slist.First;
            while (currentSItem != null)
            {
                Console.WriteLine(currentSItem.Data);

                currentSItem = currentSItem.Next;
            }

            Console.WriteLine("Max index: " + slist.GetMaxIndex());
            Console.WriteLine("Max: " + slist.GetMax());

            Console.WriteLine("next list");

            var dlist = new DoublyLinkedList<int>();
            dlist.Add(1);
            dlist.Add(2);
            dlist.Insert(2, 2);
            dlist.Insert(2, 5);
            dlist.Remove(2);
            dlist.Insert(2, 3);

            var currentDItem = dlist.First;
            while (currentDItem != null)
            {
                Console.WriteLine(currentDItem.Data);

                currentDItem = currentDItem.Next;
            }

            Console.ReadKey();
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public class SinglyLinkedList<T> where T : new()
    {
        public Node<T> First => _first;
        private Node<T> _first;

        public int Length => _length;
        private int _length = 0;

        public SinglyLinkedList()
        {
            _first = new Node<T>(new T());
        }

        public void Add(T data)
        {
            var temp = _first;
            for (var i = 0; i < _length; i++)
            {
                temp = temp.Next;
            }

            temp.Next = new Node<T>(data);

            _length++;
        }

        public bool Insert(int index, T data)
        {
            if (index < 0 || index > _length) return false;
            if (index == 0 || index == _length)
            {
                Add(data);

                return true;
            }

            var temp = _first;
            for (var i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }

            var newNode = new Node<T>(data);
            newNode.Next = temp.Next;
            temp.Next = newNode;

            _length++;

            return true;
        }

        public T Get(int index)
        {
            if (index < 0 || index > _length - 1) throw new Exception("Oh oh the given index is either to small or toooo big!");

            var temp = _first;
            for (var i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            return temp.Next.Data;
        }

        public bool Remove(int index)
        {
            if (index < 0 || index > _length) return false;

            var temp = _first;
            for (var i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            temp.Next = null;

            _length--;

            return true;
        }

        public int GetMaxIndex()
        {
            return _length - 1;
        }

        public T GetMax()
        {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            var temp = _first;
            dynamic maxVal = temp.Data;
            for (var i = 0; i < _length -1; i++)
            {
                temp = temp.Next;

                var newVal = (dynamic)temp.Data;

                if (newVal > maxVal)
                {
                    maxVal = newVal;
                }
            }

            return (T)maxVal;
        }
    }

    public class DoublyLinkedList<T> where T : new()
    {
        public Node<T> First => _first;

        private Node<T> _first;
        private Node<T> _last;

        private int _length = 0;

        public DoublyLinkedList()
        {
            _first = new Node<T>(new T());
            _last = new Node<T>(new T());
            _first.Next = _last;
            _last.Previous = _first;
        }

        public void Add(T data)
        {
            var newNode = new Node<T>(data);
            newNode.Next = _last;
            newNode.Previous = _last.Previous;
            _last.Previous.Next = newNode;
            _last.Previous = newNode;

            _length++;
        }

        public bool Insert(int index, T data)
        {
            if (index < 0 || index > _length) return false;
            if (index == 0 || index == _length)
            {
                Add(data);

                return true;
            }

            var temp = _first.Next;
            for (var i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            var newNode = new Node<T>(data);
            newNode.Next = temp;
            newNode.Previous = temp.Previous;
            temp.Previous.Next = newNode;
            temp.Previous = newNode;

            _length++;

            return true;
        }

        public bool Remove(int index)
        {
            if (index < 0 || index > _length) return false;

            var temp = _first.Next;
            for (var i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            temp.Previous.Next = temp.Next;
            temp.Next.Previous = temp.Previous;

            _length--;

            return true;
        }
    }
}