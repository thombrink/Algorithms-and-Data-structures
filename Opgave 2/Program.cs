using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_2 {
    class Program {
        static void Main(string[] args) {
            var list = new EvenOddSLL();
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.Add(3, 3);
            list.Add(4, 4);
            list.Add(5, 5);

            Console.WriteLine(list.ToString());
            Console.WriteLine(list.ToStringEven());
            Console.WriteLine(list.ToStringOdd());

            Console.WriteLine(list.Get(0));
            Console.WriteLine(list.Get(1));
            Console.WriteLine(list.Get(2));
            Console.WriteLine(list.Get(3));
            Console.WriteLine(list.Get(4));
            Console.WriteLine(list.Get(5));

            Console.WriteLine();

            //list.Remove(3);

            //Console.WriteLine(list.Get(0));
            //Console.WriteLine(list.Get(1));
            //Console.WriteLine(list.Get(2));
            //Console.WriteLine(list.Get(3));
            //Console.WriteLine(list.Get(4)); <-- gaat hier pas mis

            var tree = new BinaryTree();
            tree.AddNode(6);
            tree.AddNode(2);
            tree.AddNode(8);
            tree.AddNode(1);
            tree.AddNode(4);
            tree.AddNode(3);

            Console.WriteLine(tree.ToString());

            Console.WriteLine(tree.GeefEenNaKleinsteElement());

            Console.ReadKey();
        }
    }

    public class EvenOddSLL {
        private Node _header = new Node(-1);
        private Node _header_even = new Node(-1);
        private Node _header_odd = new Node(-1);

        public int Length => _length;
        private int _length = 0;

        public void Add(int index, int data) {
            if (index < 0 || index > _length) return;

            var temp = _header;
            for (var i = 0; i < index; i++) {
                temp = temp.Next;
            }

            var newNode = new Node(data);
            newNode.Next = temp.Next;
            temp.Next = newNode;

            // even
            if (index % 2 == 0) {
                var tempEven = _header_even;
                for (var i = 0; i < index; i+= 2) {
                    tempEven = tempEven.NextOddOrEven;
                }

                newNode.NextOddOrEven = tempEven.NextOddOrEven;
                tempEven.NextOddOrEven = newNode;
            }
            // odd
            else {
                var tempOdd = _header_odd;
                for (var i = 0; i < index - 1; i+= 2) {
                    tempOdd = tempOdd.NextOddOrEven;
                }

                newNode.NextOddOrEven = tempOdd.NextOddOrEven;
                tempOdd.NextOddOrEven = newNode;
            }

            _length++;
        }

        public int Get(int index) {
            if (index < 0 || index > _length - 1) throw new Exception("Oh oh the given index is either to small or toooo big!");

            Node temp;

            // even
            if (index % 2 == 0) {
                temp = _header_even;
                for (var i = 0; i < index; i += 2) {
                    temp = temp.NextOddOrEven;
                }
            }
            // odd
            else {
                temp = _header_odd;
                for (var i = 0; i < index - 1; i += 2) {
                    temp = temp.NextOddOrEven;
                }
            }

            return temp.NextOddOrEven.Data;
        }

        public void Remove(int index) {
            if (index < 0 || index > _length) return;

            var temp = _header;
            for (var i = 0; i < index; i++) {
                temp = temp.Next;
            }

            temp.Next = temp.Next.Next;
            temp.NextOddOrEven = temp.Next.NextOddOrEven;

            _length--;
        }

        public override string ToString() {
            // normale lijst uitprinten
            var sb = new StringBuilder();

            var currentItem = _header.Next.Next;
            while (currentItem != null) {
                sb.Append(currentItem.Data + ", ");

                currentItem = currentItem.Next;
            }

            return sb.ToString();
        }

        public string ToStringEven() {
            // alleen de even-lijst
            var sb = new StringBuilder();

            var currentItem = _header_even.NextOddOrEven;
            while (currentItem != null) {
                sb.Append(currentItem.Data + ", ");

                currentItem = currentItem.NextOddOrEven;
            }

            return sb.ToString();
        }

        public string ToStringOdd() {
            // print  alleen de odd-lijst 
            var sb = new StringBuilder();

            var currentItem = _header_odd.NextOddOrEven;
            while (currentItem != null) {
                sb.Append(currentItem.Data + ", ");

                currentItem = currentItem.NextOddOrEven;
            }

            return sb.ToString();
        }


        class Node {
            public Node Next { get; set; }
            public Node NextOddOrEven { get; set; }

            public int Data { get; set; }

            public Node(int data) {
                Data = data;
            }
        }
    }

    public class BinaryTree {
        public TreeNode RootNode { get; set; } = new TreeNode();
        public int[] treeArray = new int[50];


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

        public int GeefEenNaKleinsteElement() {
            var smallest = RootNode.Data;
            var almostSmallest = int.MaxValue;

            var currNode = RootNode;
            while(currNode != null) {
                if(currNode.Data < almostSmallest) {
                    if(currNode.Data < smallest) {
                        almostSmallest = smallest;
                        smallest = currNode.Data;
                    } else {
                        almostSmallest = currNode.Data;
                    }
                }

                currNode = currNode.LeftNode ?? currNode.RightNode;
            }

            return almostSmallest;
        }

        private void GenerateArray(TreeNode node) {
            treeArray[1] = node.Data;
            GenerateArray(node, 1);
        }

        private void GenerateArray(TreeNode node, int level) {
            if (node == null || (node.LeftNode == null && node.RightNode == null)) return;

            treeArray[level * 2] = node.LeftNode?.Data ?? 0;
            treeArray[(level * 2) + 1] = node.RightNode?.Data ?? 0;

            GenerateArray(node.LeftNode, level + 1);
            GenerateArray(node.RightNode, level + 1);
        }

        public override string ToString() {
            GenerateArray(RootNode);

            var x = Console.WindowWidth / 2;
            var space = 5;
            var rowItemCount = 0;

            var currLevel = 1;

            var sb = new StringBuilder();
            x = (Console.WindowWidth / 2) - ((space * (currLevel * 2)) / 2);
            sb.Append(new String(' ', x));

            for(var i = 1; i < 16; i++) {// max height = 4 (4 * 4 = 16)
                if(i >= currLevel * 2) {
                    currLevel++;
                    rowItemCount = 0;

                    x = (Console.WindowWidth / 2) - ((space * (currLevel * 2)) / 2);

                    sb.Append(Environment.NewLine);
                    sb.Append(new String(' ', x));
                }

                rowItemCount++;

                sb.Append(new String(' ', space) + (treeArray[i] != 0 ? treeArray[i].ToString() : string.Empty));
            }

            return sb.ToString();
        }

        public class TreeNode {
            public TreeNode LeftNode, RightNode;
            public int Data;
        }
    }
}
