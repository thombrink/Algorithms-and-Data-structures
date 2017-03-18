using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash {
    class Program {
        static void Main(string[] args) {
            var intHashValue = 1235;
            Console.WriteLine($"hash value for {intHashValue.ToString()} is {Hash.HashValue(intHashValue)}");

            var stringHashValue = "011000110";
            Console.WriteLine($"hash value for {stringHashValue} is {Hash.HashValue(stringHashValue)}");

            var tableSize1 = 5;
            var tableSize2 = 29;

            var hashTable = new SeparateChainingHashTable();
            hashTable.Add(10);
            hashTable.Add(1);
            hashTable.Add(4);
            hashTable.Add(8);
            hashTable.Add(9);
            hashTable.Add(18);
            hashTable.Add(9);

            hashTable.Delete(18);
            hashTable.Delete(9);

            hashTable.Print();

            Console.ReadKey();
        }
    }

    public class Hash {
        public static int HashValue(int x) {
            return x % 12;
        }

        public static int HashValue(int x, int tableSize) {
            return x % tableSize;
        }

        public static int HashValue(string s) {
            /*var hashValue = 0;
            for (int i = 0; i < s.Length; i++) {
                hashValue += 37 * hashValue + s[i];
            }
            return hashValue;*/
            return Convert.ToInt32(s, 2);
        }
    }

    public class SeparateChainingHashTable {
        private List<int>[] _table;
        private int _tableSize;

        public SeparateChainingHashTable(int tableSize = 9) {
            _table = new List<int>[tableSize];
            _tableSize = tableSize;
        }

        public void Add(int value) {
            var key = GetKey(value);
            if (_table[key] == null) _table[key] = new List<int>();

            _table[key].Add(value);
        }

        public void Delete(int value) {
            var key = GetKey(value);

            _table[key].Remove(value);
        }

        public void Print() {
            //hashWaarde, lijst: 
            //0:   0
            //1:   81->  1
            //2:   null
            //3:   null
            //4:   ... 

            Console.WriteLine("hashWaarde, lijst:");
            for(var i = 0; i < _table.Length; i++) {
                //Console.Write(key);
                /*foreach (var val in key) {

                }*/
                //Console.Write(Environment.NewLine);
                Console.WriteLine($"{i}: {string.Join(", ", _table[i] ?? new List<int>(0))}");
            }
        }

        private int GetKey(int value) {
            return Hash.HashValue(value, _tableSize);
        }
    }
}
