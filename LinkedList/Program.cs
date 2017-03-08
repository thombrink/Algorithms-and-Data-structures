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
            slist.Add(10);
            slist.Add(20);
            slist.Insert(2, 2);
            slist.Insert(2, 5);
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
            Console.WriteLine("Total sum: " + slist.CumulatieveSum(slist.GetMaxIndex()));
            Console.WriteLine("Max recursive: " + slist.GetMaxRecursive());

            Console.WriteLine("next list");

            var dlist = new DoublyLinkedList<int>();
            /*dlist.Add(1);
            dlist.Add(8);
            dlist.Add(2);
            dlist.Add(6);
            dlist.Add(7);
            dlist.Insert(2, 2);
            dlist.Insert(2, 5);
            dlist.Remove(2);
            dlist.Insert(2, 3);*/

            dlist.Add(3);
            dlist.Add(2);
            dlist.Add(1);
            dlist.Add(3);
            dlist.Add(2);
            dlist.Add(1);

            var currentDItem = dlist.First;
            while (currentDItem != null)
            {
                Console.WriteLine(currentDItem.Data);

                currentDItem = currentDItem.Next;
            }

            Console.WriteLine("list ordered");

            dlist.InsertionSort();

            currentDItem = dlist.First;
            while (currentDItem != null)
            {
                Console.WriteLine(currentDItem.Data);

                currentDItem = currentDItem.Next;
            }

            Console.WriteLine("reverse index 2 and 5");

            dlist.Swap(2, 5);

            currentDItem = dlist.First;
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
        private Node<T> _next { get; set; }
        private Node<T> _previous { get; set; }

        public Node<T> Previous
        {
            get
            {
                //return _previous;
                return IsReversed ? _next : _previous;
            }
            set
            {
                if (IsReversed)
                    _next = value;
                else
                    _previous = value;
            }
        }
        public Node<T> Next
        {
            get
            {
                //return _next;
                return IsReversed ? _previous : _next;
            }
            set
            {
                if (IsReversed)
                    _previous = value;
                else
                    _next = value;
            }
        }
        //public Node<T> Previous { get; set; }
        //public Node<T> Next { get; set; }
        public T Data { get; set; }
        public bool IsReversed { get; set; }


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
            var maxVal = temp.Data;
            for (var i = 0; i < _length; i++)
            {
                temp = temp.Next;

                if (((IComparable)temp.Data).CompareTo(maxVal) > 0)
                {
                    maxVal = temp.Data;
                }
            }

            return maxVal;
        }

        public T GetMaxRecursive(Node<T> node = null)
        {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            if (node == null) node = _first;

            if (node.Next == null) return default(T);

            var maxVal = node.Next.Data;

            var newVal = GetMaxRecursive(node.Next);

            if (((IComparable)newVal).CompareTo(maxVal) > 0)
            {
                maxVal = newVal;
            }

            return maxVal;
        }

        public void PrintMovingAverage(int n)
        {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            var temp = _first;
            dynamic total = 0;

            var tempArr = new T[_length];

            for (var i = 0; i < _length; i++)
            {
                temp = temp.Next;

                var newVal = (dynamic)temp.Data;

                total += newVal;
                tempArr[i] = newVal;

                if (i < n)
                {
                    Console.Write(total / (i + 1) + " ");
                }
                else
                {
                    total -= tempArr[i - n];
                    Console.Write(total / n + " ");
                }
            }
        }

        public int CumulatieveSum(int index)
        {
            var temp = _first;
            dynamic currentSum = 0;

            for (var i = 0; i < index + 1; i++)
            {
                temp = temp.Next;

                currentSum += (dynamic)temp.Data;
            }

            return currentSum;
        }
    }

    public class DoublyLinkedList<T> where T : IComparable, new()
    {
        private Node<T> _first;
        private Node<T> _last;

        private int _length = 0;

        public Node<T> First => _first;
        public int Length => _length;

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

        public void InsertionSort()
        {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            var node = _first.Next;

            for (var i = 0; i < _length; i++)
            {
                var temp = node.Data;

                var curr = node;
                for (var j = i; j > 0 && temp.CompareTo(curr.Previous.Data) < 0; j--) {
                    curr.Data = curr.Previous.Data;

                    curr = curr.Previous;
                }

                curr.Data = temp;

                node = node.Next;
            }
        }

        public void Swap(int startIndex, int endIndex)
        {
            var currNode = _first.Next;
            Node<T> start = null;
            //T startData = default(T);

            for (var i = 0; i < endIndex; i++)
            {
                if (i == startIndex) start = currNode; //startData = currNode.Data;

                currNode = currNode.Next;
            }

            var endData = currNode.Data;

            currNode.Data = start.Data;

            start.Data = endData;

            //currNode.Previous = start.Previous;
            //currNode.Next = start.Next;
            //currNode.Data = start.Data;

            //start.Previous = stop.Previous;
            //start.Next = stop.Next;
            //start.Data = stop.Data;
        }

        public int GetMaxValueIndex(int maxIndex)
        {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            var temp = _first;
            var maxVal = temp.Data;
            var maxValIndex = 0;
            var currIndex = 0;

            for (var i = 0; i <= maxIndex; i++)
            {
                temp = temp.Next;

                if (((IComparable)temp.Data).CompareTo(maxVal) > 0)
                {
                    maxVal = temp.Data;
                    maxValIndex = i;
                }
            }

            return maxValIndex;
        }

        public void Flip(int endIndex)
        {
            var firstNode = _first.Next;
            var currNode = firstNode;
            var nextNode = currNode.Next;

            for (var i = 0; i <= endIndex; i++)
            {
                nextNode = currNode.Next;
                currNode.IsReversed = !currNode.IsReversed;

                currNode = nextNode;
            }

            //Fix the first null node
            _first.Next = currNode.Previous;
            currNode.Previous.Previous = _first;

            //Fix the list if not the whole list is flipped
            currNode.Previous = firstNode;
            currNode.Previous.Next = currNode;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            var currentDItem = _first;
            while (currentDItem != null) {
                sb.Append(currentDItem.Data + ", ");

                currentDItem = currentDItem.Next;
            }
            return sb.ToString();
        }
    }
}