using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTest {
    class Program {
        static void Main(string[] args) {
            #region Opdracht 1
            Console.WriteLine("Opdracht 1 alternatief 1");
            var ass1 = new Assignment1();

            ass1.PrintLetters(3);

            Console.Write(Environment.NewLine);

            ass1.PrintLetters(0);

            Console.Write(Environment.NewLine);

            Console.WriteLine("Opdracht 1 alternatief 2");
            ass1.PrintLetters(3, 5);

            Console.Write(Environment.NewLine);

            ass1.PrintLetters(2, 0);

            Console.Write(Environment.NewLine);

            //var isPal = !ass2.IsPalindroom("test") ? "not" : " ";
            Console.WriteLine($"pap is {ass1.IsPalindroom("pap")}");
            Console.WriteLine($"abba is {ass1.IsPalindroom("abba")}");
            Console.WriteLine($"meetsysteem is {ass1.IsPalindroom("meetsysteem")}");
            Console.WriteLine($"was it a car or a cat i saw? is {ass1.IsPalindroom("was it a car or a cat i saw?")}");
            Console.WriteLine($"10201 is {ass1.IsPalindroom("10201")}");


            Console.WriteLine("Opdracht 2");
            #endregion
            #region Opdracht 2
            var sll = new EvenOddSLL();

            /*sll.Add(0, 1);
            sll.Add(1, 2);
            sll.Add(2, 4);
            sll.Add(3, 5);
            sll.Add(2, 3);

            Console.WriteLine(sll.Get(0));
            Console.WriteLine(sll.Get(1));
            Console.WriteLine(sll.Get(2));

            Console.WriteLine(sll.ToString());
            Console.WriteLine(sll.ToStringEven());
            Console.WriteLine(sll.ToStringOdd());*/

            #endregion
            #region Opdracht 3
            var tree = new BinaryTree();
            tree.AddNode(6);
            tree.AddNode(2);
            tree.AddNode(8);
            //tree.AddNode(1);
            tree.AddNode(4);
            tree.AddNode(3);

            tree.PrintTree();

            var almostSmallest = tree.GeefEenNaKleinsteElement();

            //Console.WriteLine(tree.ToString());
            #endregion
            #region Opdracht 4
            var heap = new Heap();
            heap.Add(15);
            heap.Add(4);
            heap.Add(22);
            heap.Add(2);

            Console.WriteLine(heap.ToString());

            #endregion

            Console.ReadKey();
        }
    }

    class Assignment1 {
        public void PrintLetters(int n) {
            if (n == 0) return;

            Console.Write("A");

            PrintLetters(n - 1);

            Console.Write("Z");
        }

        public void PrintLetters(int p, int q) {
            if (p <= 0 && q <= 0) return;

            if (p > 0) {
                Console.Write("A");
            }

            PrintLetters(p -1, q - 1);

            if (q > 0) {
                Console.Write("Z");
            }
        }

        public bool IsPalindroom(string s) {
            if (s.Length <= 1) return true;

            if (!Char.IsLetter(s[0])) {
                return IsPalindroom(s.Substring(1, s.Length - 1));
            }
            if (!Char.IsLetter(s[s.Length - 1])) {
                return IsPalindroom(s.Substring(0, s.Length - 1));
            }

            if (s[0] == s[s.Length - 1]) {
                return IsPalindroom(s.Substring(1, s.Length - 2));
            }
            else {
                return false;
            }
        }
    }

    class EvenOddSLL {
        private Node _header = new Node(0);
        private Node _headerEven = new Node(0);
        private Node _headerOdd = new Node(0);

        public void Add(int index, int data) {
            var temp = _header;
            var i = 0;
            for (; i < index; i++) {
                temp = temp.Next;
            }

            var newNode = new Node(data);
            newNode.Next = temp.Next;
            temp.Next = newNode;

            if ((i + 1) % 2 == 0) {
                var tempEven = _headerEven;
                for (var j = 0; j < i / 2; j++) {
                    tempEven = tempEven.NextOddOrEven;
                }

                //newNode.NextOddOrEven = tempEven.Next?.NextOddOrEven;
                tempEven.NextOddOrEven = newNode;
            }
            else {
                var tempOdd = _headerOdd;
                for (var j = 0; j < i / 2; j++) {
                    tempOdd = tempOdd.NextOddOrEven;
                }

                //newNode.NextOddOrEven = tempOdd.Next?.NextOddOrEven;
                tempOdd.Next.NextOddOrEven = newNode.Next;
            }

            return;
        }

        public int Get(int index) {
            Node temp;
            if ((index + 1) % 2 == 0) {
                temp = _headerEven;
            }
            else {
                temp = _headerOdd;
            }

            for (var i = 0; i < index / 2; i++) {
                temp = temp.NextOddOrEven;
            }

            return temp.NextOddOrEven.Data;
        }

        public bool Remove(int index) {
            var temp = _header;
            for (var i = 0; i < index; i++) {
                temp = temp.Next;
            }

            temp.Next = null;

            return true;
        }

        public override string ToString() {
            // normale lijst uitprinten 
            var sb = new StringBuilder();

            var currentItem = _header.Next;
            while (currentItem != null) {
                sb.Append(currentItem.Data + ", ");

                currentItem = currentItem.Next;
            }

            return sb.ToString();
        }

        public string ToStringEven() {
            // alleen de even-lijst 
            var sb = new StringBuilder();

            var currentItem = _headerEven.NextOddOrEven;
            //var currentItem = _header.NextOddOrEven;
            while (currentItem != null) {
                sb.Append(currentItem.Data + ", ");

                currentItem = currentItem.NextOddOrEven;
                //currentItem = currentItem.NextOddOrEven;
            }

            return sb.ToString();
        }

        public string ToStringOdd() {
            // print  alleen de odd-lijst 
            var sb = new StringBuilder();

            var currentItem = _headerOdd.NextOddOrEven;
            //var currentItem = _header.Next;
            while (currentItem != null) {
                sb.Append(currentItem.Data + ", ");

                currentItem = currentItem.NextOddOrEven;
                //currentItem = currentItem.NextOddOrEven;
            }

            return sb.ToString();
        }

        class Node {
            public Node Next { get; set; }
            public Node NextOddOrEven { get; set; }
            //public Node NextOddOrEven {
            //    get {
            //        return Next?.Next;
            //    }
            //}

            public int Data { get; set; }

            public Node(int data) {
                Data = data;
            }
        }
    }

    class BinaryTree {
        public TreeNode RootNode { get; set; } = new TreeNode();

        public void AddNode(int value) {
            if (RootNode.Data == default(uint)) {
                RootNode.Data = value;
            }
            else {
                TreeNode currentNode = RootNode;
                TreeNode nextNode = value < currentNode?.Data ? currentNode?.LeftNode : currentNode?.RightNode;
                while (nextNode != null) {
                    currentNode = nextNode;

                    // having fun woohoooo
                    if (value > nextNode?.Data) {
                        nextNode = nextNode.RightNode;
                    }
                    else {
                        nextNode = nextNode.LeftNode;
                    }
                }

                // oke, I wanna stop here and do some changes
                if (value > currentNode?.Data) {
                    currentNode.RightNode = new TreeNode() { Data = value };
                }
                else {
                    currentNode.LeftNode = new TreeNode() { Data = value };
                }
            }
        }

        public int GetLeaves() {
            return GetLeaves(RootNode);
        }

        public int GetLeaves(TreeNode currentNode) {
            int leaveCount = 0;
            if (currentNode == null) return leaveCount;

            if (currentNode.LeftNode != null || currentNode.RightNode != null) {
                leaveCount += GetLeaves(currentNode.LeftNode);
                leaveCount += GetLeaves(currentNode.RightNode);
            }
            else {
                leaveCount++;
            }

            return leaveCount;
        }

        public void PrintTree() {
            PrintTree(RootNode, Console.WindowWidth / 2, Console.CursorTop);
        }

        private void PrintTree(TreeNode currentNode, int x, int y) {
            //if (currentNode == null) return;

            Console.SetCursorPosition(x, y);
            Console.Write($"[{currentNode.Data}]");

            if(currentNode.LeftNode != null) {
                Console.SetCursorPosition(x - 3, y + 2);
                Console.Write("/");
                PrintTree(currentNode.LeftNode, x - 6, y + 4);
                
            }
            if(currentNode.RightNode != null) {
                Console.SetCursorPosition(x + 5, y + 2);
                Console.Write(@"\");
                PrintTree(currentNode.RightNode, x + 6, y + 4);
            }
        }

        public int GeefEenNaKleinsteElement() {
            var smallest = int.MaxValue;
            var almostSmallest = int.MaxValue;

            TreeNode previousNode = null;
            TreeNode currentNode = RootNode;

            while (currentNode != null) {
                if(currentNode.Data < almostSmallest) {
                    if (currentNode.Data < smallest) {
                        almostSmallest = smallest;
                        smallest = currentNode.Data;
                    }
                    else {
                        almostSmallest = currentNode.Data;
                    }
                }

                previousNode = currentNode;
                currentNode = currentNode.LeftNode ?? currentNode.RightNode;
            }

            return almostSmallest;
        }

        /*public override string ToString() {
            return PrintNode(RootNode, Console.WindowWidth / 2, Console.CursorTop);
        }*/

        public class TreeNode {
            public TreeNode LeftNode, RightNode;
            public int Data;
        }
    }

    class Heap {
        int[] _array = new int[10];
        int _length = 0;

        public Heap() {

        }

        public void Add(int value) {
            var i = _length;
            var pos = i;
            for (; _array[i / 2] > value && i > 0; i /= 2) {
                pos = i / 2;
                _array[i] = _array[pos];
            }
            _array[pos] = value;
            _length++;
        }

        public override string ToString() {
            var sb = new StringBuilder();

            for(var i = 0; i < _length; i++) {
                sb.Append(_array[i] + ", ");
            }

            for (var i = _length; i < _array.Length; i++) {
                sb.Append("#, ");
            }

            return sb.ToString();
        }
    }
}
