using LinkedList;
using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //( ( ( ) ( ) ) ) is een geldige string
            //( ) ) is geen geldige string 
            CheckBrackets("( ( ( ) ( ) ) )");

            Console.ReadKey();
        }

        static bool CheckBrackets(string s)
        {
            var stack = new Stack<char>();
            foreach (var b in s.Trim((char)32).ToCharArray())
            {
                stack.Push(b);
            }

            var item = stack.Pop();
            while (item > 0)
            {
                item = stack.Pop();
            }
            
            return true;
        }
    }

    interface IStack<T> {
        void Push(T data);
        T Pop();
        T Top();
    }

    class Stack<T> : IStack<T> where T: new()
    {
        SinglyLinkedList<T> _linkedList;

        public Stack()
        {
            _linkedList = new SinglyLinkedList<T>();
        }

        public T Pop()
        {
            var index = _linkedList.Length - 1;
            var value = _linkedList.Get(index);
            _linkedList.Remove(index);
            return value;
        }

        public void Push(T data)
        {
            _linkedList.Add(data);
        }

        public T Top()
        {
            var index = _linkedList.Length - 1;
            return _linkedList.Get(index);
        }
    }
}
