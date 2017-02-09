using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(4);
            queue.Enqueue(1);
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.ReadKey();
        }
    }

    class Queue<T>
    {
        T[] _array;
        int _first, _last;
        bool _lastIndexReached;

        public Queue(int capacity)
        {
            _array = new T[capacity];
        }

        public T Dequeue()
        {
            if (_first > _array.Length - 1)
            {
                _first = 0;
            }

            return _array[_first++];
        }

        public void Enqueue(T data)
        {
            if(_lastIndexReached && _last == _first)
            {
                //Resize
                var newArray = new T[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    var index = i + _first;
                    if(index >= _array.Length)
                    {
                        index = i - _first;// index % _array.Length;
                    }
                    newArray[i] = _array[index];
                }

                _first = 0;
                _last = _array.Length;

                _array = newArray;

                _lastIndexReached = false;
            }

            _array[_last++] = data;

            if (_last > _array.Length - 1)
            {
                _last = 0;
                _lastIndexReached = true;
            }
        }
    }
}
