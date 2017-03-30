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

            sll.Add(0, 0);
            sll.Add(1, 1);
            sll.Add(2, 2);
            sll.Add(3, 4);
            sll.Add(4, 5);
            sll.Add(5, 6);
            sll.Add(6, 7);
            sll.Add(7, 8);
            sll.Add(8, 9);
            sll.Add(9, 10);
            sll.Add(3, 3);


            //sll.Add(0, 0);
            //sll.Add(1, 1);
            //sll.Add(2, 2);
            //sll.Add(3, 3);
            //sll.Add(4, 4);
            //sll.Add(5, 5);

            //sll.Add(0, 1);
            //sll.Add(1, 2);
            //sll.Add(2, 4);
            //sll.Add(3, 5);
            //sll.Add(2, 3);

            //Console.WriteLine(sll.Get(0));
            //Console.WriteLine(sll.Get(1));
            //Console.WriteLine(sll.Get(2));

            Console.WriteLine(sll.ToString());
            Console.WriteLine(sll.ToStringEven());
            Console.WriteLine(sll.ToStringOdd());

            //LinkedList llist = new LinkedList();
            //llist.push(11);
            //llist.push(10);
            //llist.push(8);
            //llist.push(6);
            //llist.push(4);
            //llist.push(2);
            //llist.push(0);
            //Console.WriteLine("Origional Linked List");
            //llist.printList();

            //llist.segregateEvenOdd();

            //Console.WriteLine("Modified Linked List");
            //llist.printList();

            #endregion
            #region Opdracht 3
            var tree = new BinaryTree();
            //tree.AddNode(6);
            //tree.AddNode(2);
            //tree.AddNode(8);
            //tree.AddNode(1);
            //tree.AddNode(4);
            //tree.AddNode(3);
            tree.AddNode(5);
            tree.AddNode(3);
            tree.AddNode(6);
            tree.AddNode(4);
            tree.AddNode(2);
            tree.AddNode(7);

            //tree.PrintTree();

            var almostSmallest = tree.GeefEenNaKleinsteElement();

            Console.WriteLine(tree.ToString());
            //Console.SetCursorPosition(0, 30);
            #endregion
            #region Opdracht 4
            var heap = new Heap();
            heap.Add(15);
            heap.Add(4);
            heap.Add(22);
            heap.Add(2);
            heap.Add(2);
            heap.Add(2);
            heap.Add(2);
            heap.Add(2);
            heap.Add(2);

            Console.WriteLine(heap.ToString());

            Console.WriteLine("Is complete: " + heap.IsComplete());

            heap.BreakHeap();

            Console.WriteLine("Is complete: " + heap.IsComplete());

            Console.WriteLine("Is max heap: " + heap.IsMaxHeap());

            var myBeautifulTreee = heap.ConverteerNaarBoom();

            #endregion
            #region Opdracht 5

            var graph = new Graph();
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "G");

            graph.AddEdge("C", "B");

            graph.AddEdge("D", "F");
            graph.AddEdge("D", "G");

            graph.AddEdge("E", "C");

            graph.AddEdge("F", "F");

            graph.AddEdge("G", "D");
            graph.AddEdge("G", "F");
            graph.AddEdge("G", "H");

            graph.AddEdge("H", "E");
            graph.AddEdge("H", "K");

            graph.AddEdge("K", "G");

            //graph.Calculate("G");

            Console.WriteLine("E has cycle: " + graph.HasCycle("E"));
            Console.WriteLine("K has cycle: " + graph.HasCycle("K"));

            graph.ToonCycle();

            graph.ToonAfstand("G");

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

            PrintLetters(p - 1, q - 1);

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
        private Node _header = new Node(-1);
        //private Node _headerEven = new Node(0);
        //private Node _headerOdd = new Node(0);

        public void Add(int index, int data) {
            Node temp = _header;

            var currIndex = 0;
            while (temp.Next != null && currIndex < index - 1) {
                temp = temp.Next;

                currIndex++;
            }

            var newNode = new Node(data);
            newNode.Next = temp.Next?.Next;

            if (temp.Next != null) {
                temp.Next.Next = newNode;
            }
            else {
                temp.Next = newNode;
            }

            temp.NextOddOrEven = newNode;
        }

        //public int Get(int index) {
        //    Node temp;
        //    if ((index + 1) % 2 == 0) {
        //        temp = _headerEven;
        //    }
        //    else {
        //        temp = _headerOdd;
        //    }

        //    for (var i = 0; i < index / 2; i++) {
        //        temp = temp.NextOddOrEven;
        //    }

        //    return temp.NextOddOrEven.Data;
        //}

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

            var currentItem = _header.Next.NextOddOrEven;
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

            var currentItem = _header.NextOddOrEven;
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

    class LinkedList {
        Node head;  // head of list

        /* Linked list Node*/
        class Node {
            public int data;
            public Node next;
            public Node(int d) {
                data = d;
                next = null;
            }
        }

        public void segregateEvenOdd() {
            Node end = head;
            Node prev = null;
            Node curr = head;

            /* Get pointer to last Node */
            while (end.next != null)
                end = end.next;

            Node new_end = end;

            // Consider all odd nodes before getting first eve node
            while (curr.data % 2 != 0 && curr != end) {
                new_end.next = curr;
                curr = curr.next;
                new_end.next.next = null;
                new_end = new_end.next;
            }

            // do following steps only if there is an even node
            if (curr.data % 2 == 0) {
                head = curr;

                // now curr points to first even node
                while (curr != end) {
                    if (curr.data % 2 == 0) {
                        prev = curr;
                        curr = curr.next;
                    }
                    else {
                        /* Break the link between prev and curr*/
                        prev.next = curr.next;

                        /* Make next of curr as null */
                        curr.next = null;

                        /*Move curr to end */
                        new_end.next = curr;

                        /*Make curr as new end of list */
                        new_end = curr;

                        /*Update curr pointer */
                        curr = prev.next;
                    }
                }
            }

            /* We have to set prev before executing rest of this code */
            else prev = curr;

            if (new_end != end && end.data % 2 != 0) {
                prev.next = end.next;
                end.next = null;
                new_end.next = end;
            }
        }

        /*  Given a reference (pointer to pointer) to the head
            of a list and an int, push a new node on the front
            of the list. */
        public void push(int new_data) {
            /* 1 & 2: Allocate the Node &
                      Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        // Utility function to print a linked list
        public void printList() {
            Node temp = head;
            while (temp != null) {
                Console.WriteLine(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }

    public class BinaryTree {
        public TreeNode RootNode { get; set; } = new TreeNode();
        private int _currRow = 0;
        private int _lineWidth = Console.WindowWidth;

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

            if (currentNode.LeftNode != null) {
                Console.SetCursorPosition(x - 3, y + 2);
                Console.Write("/");
                PrintTree(currentNode.LeftNode, x - 6, y + 4);

            }
            if (currentNode.RightNode != null) {
                Console.SetCursorPosition(x + 5, y + 2);
                Console.Write(@"\");
                PrintTree(currentNode.RightNode, x + 6, y + 4);
            }
        }

        public string GetTree() {
            var sb = new StringBuilder(new String(' ', _lineWidth));
            GetTree(sb, RootNode, _lineWidth / 2, 0);
            return sb.ToString();
        }

        private void GetTree(StringBuilder sb, TreeNode currentNode, int x, int row) {
            if (_currRow < row) {
                sb.Append(new String(' ', _lineWidth));
                _currRow++;
            }

            var currRow = row * _lineWidth;

            var parentIndex = currRow + x;
            sb[parentIndex - 1] = '[';
            sb[parentIndex] = currentNode.Data.ToString().ToCharArray()[0];
            sb[parentIndex + 1] = ']';

            sb.Replace("   ", $"[{currentNode.Data}]", parentIndex - 1, 3);

            //sb[currRow + x] = $"[{currentNode.Data}]";
            //Console.SetCursorPosition(x, level);
            //Console.Write($"[{currentNode.Data}]");

            if (currentNode.LeftNode != null) {
                if (_currRow < row + 1) {
                    sb.Append(new String(' ', _lineWidth));
                    _currRow++;
                }

                currRow = (row + 1) * _lineWidth;

                sb[currRow + x - 3] = '/';

                //Console.SetCursorPosition(x - 3, level + 1);
                //Console.Write("/");
                GetTree(sb, currentNode.LeftNode, x - 6, row + 2);

            }
            if (currentNode.RightNode != null) {
                if (_currRow < row + 1) {
                    sb.Append(new String(' ', _lineWidth));
                    _currRow++;
                }

                currRow = (row + 1) * _lineWidth;

                sb[currRow + x + 3] = '\\';

                //Console.SetCursorPosition(x + 5, level + 1);
                //Console.Write(@"\");
                GetTree(sb, currentNode.RightNode, x + 6, row + 2);
            }
        }

        public int GeefEenNaKleinsteElement() {
            var smallest = int.MaxValue;
            var almostSmallest = int.MaxValue;

            TreeNode previousNode = null;
            TreeNode currentNode = RootNode;

            while (currentNode != null) {
                if (currentNode.Data < almostSmallest) {
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

        public override string ToString() {
            //var sb = new StringBuilder(GetTree());
            // for (var i = _lineWidth; i < sb.Length; i += _lineWidth) {
            //sb.Append(Environment.NewLine, i, 1);
            //}
            //return sb.ToString();
            return GetTree();
        }

        public class TreeNode {
            public TreeNode LeftNode, RightNode;
            public int Data;
        }
    }

    class Heap {
        int[] _array = new int[10];
        int _length = 1;

        public void Add(int value) {
            var i = _length;
            var pos = i;
            for (; _array[i / 2] > value && i > 1; i /= 2) {
                pos = i / 2;
                _array[i] = _array[pos];
            }
            _array[pos] = value;
            _length++;
        }

        public void BreakHeap() {
            _array[2] = 0;
        }

        public bool IsComplete() {
            // Geeft true indien de BT compleet is en anders false
            var hasPassedEnd = false;
            for (var i = 1; i < _length; i++) {
                if (hasPassedEnd && _array[i] > 0) return false;
                if (_array[i] == 0) { hasPassedEnd = true; }
            }
            return true;
        }

        public bool IsMaxHeap() {
            //Geeft true indien de BT een maxheap is en anders false
            for (var i = 1; i * 2 + 1 < _array.Length; i++) {
                var parent = _array[i];
                var left = _array[i * 2];
                var right = _array[i * 2 + 1];

                if (left > parent || right > parent) {
                    return false;
                }
            }

            return true;
        }

        public BinaryTree ConverteerNaarBoom() {
            var tree = new BinaryTree();
            for (var i = 1; i * 2 + 1 < _array.Length; i++) {
                tree.AddNode(_array[i]);
                tree.AddNode(_array[i * 2]);
                tree.AddNode(_array[i * 2 + 1]);
            }
            return tree;
        }

        public override string ToString() {
            var sb = new StringBuilder();

            sb.Append("#, ");

            for (var i = 1; i < _length; i++) {
                sb.Append(_array[i] + ", ");
            }

            for (var i = _length; i < _array.Length; i++) {
                sb.Append("#, ");
            }

            return sb.ToString();
        }
    }

    class Heap<T> where T : IComparable {
        T[] _array = new T[10];
        int _length = 1;

        public void Add(T value) {
            var i = _length;
            var pos = i;
            for (; _array[i / 2].CompareTo(value) > 0 && i > 1; i /= 2) {
                pos = i / 2;
                _array[i] = _array[pos];
            }
            _array[pos] = value;
            _length++;
        }

        public override string ToString() {
            var sb = new StringBuilder();

            sb.Append("#, ");

            for (var i = 1; i < _length; i++) {
                sb.Append(_array[i] + ", ");
            }

            for (var i = _length; i < _array.Length; i++) {
                sb.Append("#, ");
            }

            return sb.ToString();
        }
    }

    public class Graph {
        private Dictionary<string, Node> nodeMap = new Dictionary<string, Node>();

        public void AddEdge(string sourceName, string destinationName, int cost = 1) {
            Node source = GetNode(sourceName);
            Node destination = GetNode(destinationName);
            source.Edges.Add(new Edge(destination, cost));
        }

        public void Calculate(string startNodeName) {
            Node startNode = GetNode(startNodeName);

            var nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(startNode);

            foreach (var node in nodeMap.Values) {
                node.Processed = false;
                node.Distance = int.MaxValue;
                node.Previous = null;
            }

            startNode.Distance = 0;

            while (nodeQueue.Any()) {
                var currNode = nodeQueue.Dequeue();

                if (currNode.Processed) continue;
                currNode.Processed = true;

                foreach (var edge in currNode.Edges) {
                    var destination = edge.Destination;
                    var newDistance = currNode.Distance + edge.Cost;

                    //if (destination.Distance == int.MaxValue) {
                    if (newDistance < destination.Distance) {
                        destination.Distance = newDistance;
                        destination.Previous = currNode;

                        nodeQueue.Enqueue(destination);
                    }
                }
            }
        }

        public bool HasCycle(string startNodeName) {
            Node startNode = GetNode(startNodeName);

            var nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(startNode);

            foreach (var node in nodeMap.Values) {
                node.Processed = false;
                node.Distance = int.MaxValue;
                node.Previous = null;
            }

            startNode.Distance = 0;

            while (nodeQueue.Any()) {
                var currNode = nodeQueue.Dequeue();

                if (currNode.Processed) continue;
                currNode.Processed = true;

                foreach (var edge in currNode.Edges) {
                    if (startNode.Name == edge.Destination.Name) return true;

                    nodeQueue.Enqueue(edge.Destination);
                }
            }

            return false;
        }

        public bool IsConnected() {
            Node startNode = nodeMap.First().Value;

            var nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(startNode);

            foreach (var node in nodeMap.Values) {
                node.Processed = false;
                node.Distance = int.MaxValue;
                node.Previous = null;
            }

            while (nodeQueue.Any()) {
                var currNode = nodeQueue.Dequeue();

                if (currNode.Processed) continue;
                currNode.Processed = true;

                foreach (var edge in currNode.Edges) {
                    var destination = edge.Destination;

                    if (destination.Distance == int.MaxValue) {
                        nodeQueue.Enqueue(destination);
                    }
                }
            }

            return nodeMap.All(x => x.Value.Processed);
        }

        private Node GetNode(string name) {
            Node result;
            if (nodeMap.ContainsKey(name)) {
                result = nodeMap[name];
            }
            else {
                result = new Node(name);
                nodeMap.Add(name, result);
            }
            return result;
        }

        public void Print() {
            var sb = new StringBuilder();
            foreach (var node in nodeMap) {
                sb.AppendLine(node.Key);

                foreach (var edge in node.Value.Edges) {
                    sb.AppendLine("- " + edge.Destination.Name);
                }

                sb.AppendLine();
            }
            Console.Write(sb.ToString());
        }

        public void ToonCycle() {
            foreach (var node in nodeMap) {
                Console.WriteLine("Node: " + node.Key + ", Has cycle: " + HasCycle(node.Key));
            }
        }

        public void ToonAfstand(string startNodeName) {
            Calculate(startNodeName);

            foreach (var node in nodeMap) {
                if (node.Key == startNodeName) continue;

                Console.WriteLine("Node: " + node.Key + ", Distance: " + (node.Value.Distance == int.MaxValue ? -1 : node.Value.Distance));
            }
        }

        public class Node {
            public string Name { get; set; }
            public List<Edge> Edges { get; set; } = new List<Edge>();
            public int Distance { get; set; }
            public Node Previous { get; set; }
            public bool Processed { get; set; }

            public Node(string name) {
                Name = name;
            }
        }

        public class Edge {
            public Node Destination { get; set; }
            public int Cost { get; set; }

            public Edge(Node destination, int cost) {
                Destination = destination;
                Cost = cost;
            }
        }
    }
}
