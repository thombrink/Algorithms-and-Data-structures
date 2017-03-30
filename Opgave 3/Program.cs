using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_3 {
    class Program {
        static void Main(string[] args) {
            var heap = new Heap();
            heap.Add(10);
            heap.Add(4);
            heap.Add(7);
            heap.Add(1);
            heap.Add(3);
            heap.Add(5);

            Console.WriteLine(heap.ToString());

            Console.WriteLine(heap.IsComplete());
            Console.WriteLine(heap.IsMaxHeap());
            Console.WriteLine(heap.IsMinHeap());

            var bt = heap.ConverteerNaarBoom();
            bt.PrintTree();

            Console.ReadKey();

        }
    }

    public class Heap {
        private int[] _array;
        private int _length = 1;

        public Heap() {
            _array = new int[5];
        }

        public void Add(int value) {
            if (_length == _array.Length) DoubleArraySize();

            var i = _length;
            var pos = i;
            for (; _array[i / 2] > value && i > 1; i /= 2) {
                pos = i / 2;
                _array[i] = _array[pos];
            }
            _array[pos] = value;

            _length++;
        }

        private void DoubleArraySize() {
            var newArray = new int[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++) {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }

        public bool IsComplete() {
            // Geeft true indien de BT compleet is en anders false

            for(var i = 1; i < _length; i++) {
                //if (_array[i * 2] == 0 && _array[(i * 2) + 1] != 0) return false;
                if (_array[i] == 0 && _array[i + 1] != 0) return false;
            }

            return true;
        }

        public bool IsMaxHeap() {
            //Geeft true indien de BT een maxheap is en anders false 

            for (var i = 1; i < _length; i++) {
                var left = i * 2;
                var right = left + 1;

                if (left >= _length && right >= _length) break;

                if (_array[i] < _array[left]) {
                    if (left >= _length) break;

                    return false;
                }
                else if (_array[i] < _array[right]) {
                    if (right >= _length) break;

                    return false;
                }
            }

            return true;
        }

        public bool IsMinHeap() {
            //Geeft true indien de BT een maxheap is en anders false 

            for (var i = 1; i < _length; i++) {
                var left = i * 2;
                var right = left + 1;

                if (left >= _length && right >= _length) break;

                if (_array[i] > _array[left]) {
                    if (left >= _length) break;

                    return false;
                } else if (_array[i] > _array[right]) {
                    if (right >= _length) break;

                    return false;
                }
            }

            return true;
        }

        public PracticeTest.BinaryTree ConverteerNaarBoom() {
            var bt = new PracticeTest.BinaryTree();

            for(var i = 0; i < _length; i++) {
                bt.AddNode(_array[i]);
            }

            return bt;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("#, ");

            for (var i = 1; i < _length; i++) {
                sb.Append(_array[i] +", ");
            }

            for (var i = _length; i < _array.Length; i++) {
                sb.Append("#, ");
            }

            return sb.ToString();
        }
    }
}
