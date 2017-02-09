using LinkedList;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("( ( ( ) ( ) ) ) is " + CheckBrackets("( ( ( ) ( ) ) )"));
            Console.WriteLine("( ) ) is " + CheckBrackets("( ) )"));

            Console.WriteLine("[ (( [ ])) ( ) ] is " + CheckBrackets("[ (( [ ])) ( ) ]"));
            Console.WriteLine("([ ) ] is " + CheckBrackets("([ ) ]"));

            Console.ReadKey();
        }

        static bool CheckBrackets(string s)
        {
            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                var sub = char.Parse(s.Substring(i, 1));
                switch (sub)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(sub);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        if (stack.Length == 0) return false;

                        switch (stack.Pop())
                        {
                            case '(':
                                if (sub != ')') return false;
                                break;
                            case '{':
                                if (sub != '}') return false;
                                break;
                            case '[':
                                if (sub != ']') return false;
                                break;
                        }

                        break;
                }
            }

            return stack.Length == 0;
        }
    }

    interface IStack<T>
    {
        void Push(T data);
        T Pop();
        T Top();
    }

    class Stack<T> : IStack<T> where T : new()
    {
        SinglyLinkedList<T> _linkedList;
        public int Length => _linkedList.Length;

        public Stack()
        {
            _linkedList = new SinglyLinkedList<T>();
        }

        public T Pop()
        {
            var index = _linkedList.Length - 1;
            if (index < 0) return default(T); //throw new InsufficientExecutionStackException("There are no items on the stack");

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
            if (index < 0) return default(T);
            return _linkedList.Get(index);
        }
    }
}
