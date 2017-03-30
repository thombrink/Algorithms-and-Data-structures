using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class Program {
        static void Main(string[] args) {
            var list = new SinglyLinkedList<int>();
            for (var i = 0; i < 6; i++) {
                list.Add(i);
            }

            Console.WriteLine(list.ToString());
            list.Reverse();
            Console.WriteLine(list.ToString());
            Console.ReadKey();
        }
    }

    public class Node<T> {
        private Node<T> _next { get; set; }
        private Node<T> _previous { get; set; }

        public Node<T> Previous {
            get {
                //return _previous;
                return IsReversed ? _next : _previous;
            }
            set {
                if (IsReversed)
                    _next = value;
                else
                    _previous = value;
            }
        }
        public Node<T> Next {
            get {
                //return _next;
                return IsReversed ? _previous : _next;
            }
            set {
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


        public Node(T data) {
            Data = data;
        }
    }

    public class SinglyLinkedList<T> where T : new() {
        private Node<T> _first;

        public int Length => _length;
        private int _length = 0;

        public SinglyLinkedList() {
            _first = new Node<T>(new T());
        }

        public void Add(T data) {
            var temp = _first;
            for (var i = 0; i < _length; i++) {
                temp = temp.Next;
            }

            temp.Next = new Node<T>(data);

            _length++;
        }

        public bool Insert(int index, T data) {
            if (index < 0 || index > _length) return false;
            if (index == 0 || index == _length) {
                Add(data);

                return true;
            }

            var temp = _first;
            for (var i = 0; i < index - 1; i++) {
                temp = temp.Next;
            }

            var newNode = new Node<T>(data);
            newNode.Next = temp.Next;
            temp.Next = newNode;

            _length++;

            return true;
        }

        public T Get(int index) {
            if (index < 0 || index > _length - 1) throw new Exception("Oh oh the given index is either to small or toooo big!");

            var temp = _first;
            for (var i = 0; i < index; i++) {
                temp = temp.Next;
            }

            return temp.Next.Data;
        }

        public bool Remove(int index) {
            if (index < 0 || index > _length) return false;

            var temp = _first;
            for (var i = 0; i < index; i++) {
                temp = temp.Next;
            }

            temp.Next = temp.Next?.Next;

            _length--;

            return true;
        }

        public int GetMaxIndex() {
            return _length - 1;
        }

        public T GetMax() {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            var temp = _first;
            var maxVal = temp.Data;
            for (var i = 0; i < _length; i++) {
                temp = temp.Next;

                if (((IComparable)temp.Data).CompareTo(maxVal) > 0) {
                    maxVal = temp.Data;
                }
            }

            return maxVal;
        }

        public T GetMaxRecursive(Node<T> node = null) {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            if (node == null) node = _first;

            if (node.Next == null) return default(T);

            var maxVal = node.Next.Data;

            var newVal = GetMaxRecursive(node.Next);

            if (((IComparable)newVal).CompareTo(maxVal) > 0) {
                maxVal = newVal;
            }

            return maxVal;
        }

        public void PrintMovingAverage(int n) {
            if (_length == 0) throw new Exception("Oh oh there are no items in the list!");

            var temp = _first;
            dynamic total = 0;

            var tempArr = new T[_length];

            for (var i = 0; i < _length; i++) {
                temp = temp.Next;

                var newVal = (dynamic)temp.Data;

                total += newVal;
                tempArr[i] = newVal;

                if (i < n) {
                    Console.Write(total / (i + 1) + " ");
                }
                else {
                    total -= tempArr[i - n];
                    Console.Write(total / n + " ");
                }
            }
        }

        public int CumulatieveSum(int index) {
            var temp = _first;
            dynamic currentSum = 0;

            for (var i = 0; i < index + 1; i++) {
                temp = temp.Next;

                currentSum += (dynamic)temp.Data;
            }

            return currentSum;
        }

        public void Reverse() {
            var stack = new Stack<Node<T>>();

            var currentItem = _first.Next;
            while (currentItem != null) {
                stack.Push(currentItem);

                currentItem = currentItem.Next;
            }

            _first = new Node<T>(default(T));
            currentItem = _first;
            while(stack.Count > 0) {
                var next = stack.Pop();
                next.Next = stack.Count > 0 ? stack.Peek() : null;
                currentItem.Next = next;

                currentItem = currentItem.Next;
            }
        }

        public override string ToString() {
            // normale lijst uitprinten 
            var sb = new StringBuilder();

            var currentItem = _first.Next;
            while (currentItem != null) {
                sb.Append(currentItem.Data + ", ");

                currentItem = currentItem.Next;
            }

            return sb.ToString();
        }
    }
}