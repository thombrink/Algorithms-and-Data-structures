using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ArrayList<int>(2);
            list.Add(1);
            list.Add(5);
            list.Add(2);
            Console.WriteLine(list.Get(0) == 1);
            list.Set(0, 2);
            list.Print();
            Console.WriteLine(list.CountOccurences(2) == 2);

            Console.WriteLine(list.GetMax() == 5);
            Console.WriteLine(list.GetMaxIndex() == 2);

            list.Clear();
            Console.WriteLine(list.CountOccurences(2) == 0);

            Console.ReadKey();
        }
    }

    interface SimpleArrayList<T>
    {
        void Add(T n); // toevoegen aan het einde van de lijst, mits de lijst niet vol is
        T Get(int index); // haal de waarde op van een bepaalde index
        void Set(int index, T n); // wijzig een item op een bepaalde index
        void Print(); // print de inhoud van de list
        void Clear(); // maak de list leeg
        int CountOccurences(T n); // tel hoe vaak het gegeven getal voorkomt
    }

    class ArrayList<T> : SimpleArrayList<T> where T : new()
    {
        T[] _array;
        int _nextIndex = 0;

        public ArrayList()
        {
            _array = new T[4];
        }

        public ArrayList(int capacity)
        {
            _array = new T[capacity];
        }

        public void Add(T n)
        {
            if (_nextIndex == _array.Length)
            {
                //Resize
                var newArray = new T[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }

            _array[_nextIndex] = n;
            _nextIndex++;
        }

        public void Clear()
        {
            _array = new T[_array.Length];
            _nextIndex = 0;
        }

        public int CountOccurences(T n)
        {
            var occurences = 0;
            for (var i = 0; i < _array.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[i], n))
                {
                    occurences++;
                }
            }
            return occurences;
        }

        public T Get(int index)
        {
            if (index < 0 || index > _array.Length) throw new Exception("Invalid index!");
            return _array[index];
        }

        public void Set(int index, T n)
        {
            if (index < 0 || index > _array.Length) throw new Exception("Invalid index!");
            _array[index] = n;
        }

        public int GetMaxIndex()
        {
            return _nextIndex - 1;
        }

        public T GetMax()
        {
            if (_nextIndex == 0) throw new Exception("Oh oh there are no items in the list!");

            dynamic maxVal = Get(0);

            for (var i = 1; i < _array.Length; i++)
            {
                var newVal = (dynamic)_array[i];

                if (newVal > maxVal)
                {
                    maxVal = newVal;
                }
            }

            return maxVal;
        }

        public void Print()
        {
            Console.Write("Itemcount: " + _nextIndex + ", Items: ");
            for (var i = 0; i < _nextIndex; i++)
            {
                Console.Write(_array[i] + ", ");
            }
            Console.Write(Environment.NewLine);
        }
    }
}
