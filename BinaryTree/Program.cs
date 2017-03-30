using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Does not function correctly! Look at the practice test example");
            Console.ReadKey();

            var testTree1 = new BinaryTree();
            testTree1.AddNode1(5);
            testTree1.AddNode1(3);
            testTree1.AddNode1(6);
            testTree1.AddNode1(4);
            testTree1.AddNode1(2);
            testTree1.AddNode1(7);

            var testTree2 = new BinaryTree();
            testTree2.AddNode1(50);
            testTree2.AddNode1(30);
            testTree2.AddNode1(60);
            testTree2.AddNode1(40);
            testTree2.AddNode1(20);
            testTree2.AddNode1(70);
            testTree2.AddNode1(38);

            Console.WriteLine(testTree2.GetLeaves());

            Console.WriteLine(testTree2.GetTree());

            Console.ReadKey();
        }
    }

    public class BinaryTree<T> {
        public TreeNode<T> RootNode { get; set; } = new TreeNode<T>();
    }

    public class BinaryTree {
        private int _currRow = 0;
        private int _lineWidth = Console.WindowWidth;

        public TreeNode<uint> RootNode { get; set; } = new TreeNode<uint>();

        public void AddNode1(uint value) {
            if (RootNode.Data == default(uint)) {
                RootNode.Data = value;
            }
            else {
                TreeNode<uint> currentNode = RootNode;
                TreeNode<uint> nextNode = value < currentNode?.Data ? currentNode?.LeftNode : currentNode?.RightNode;
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
                    currentNode.RightNode = new TreeNode<uint>() { Data = value };
                } else {
                    currentNode.LeftNode = new TreeNode<uint>() { Data = value };    
                }
            }
        }

        public void AddNode2(uint value) {
            if (RootNode.Data == default(uint)) {
                RootNode.Data = value;
            }
            else {
                TreeNode<uint> currentNode = RootNode;
                /*while (currentNode != null) {
                    // having fun woohoooo
                    if (value > currentNode?.Data) {
                        currentNode = currentNode.RightNode;
                    }
                    else {
                        currentNode = currentNode.LeftNode;
                    }
                }*/

                while ((currentNode = value > currentNode?.Data ? currentNode.RightNode : currentNode.LeftNode) != null) {
                    // having fun woohoooo
                }

                // oke, I wanna stop here and do some changes
                if (value > currentNode?.Data) {
                    currentNode.RightNode = new TreeNode<uint>() { Data = value };
                }
                else {
                    currentNode.LeftNode = new TreeNode<uint>() { Data = value };
                }
            }
        }

        public int GetLeaves() {
            return GetLeaves(RootNode);
        }

        public int GetLeaves(TreeNode<uint> currentNode) {
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

        public string GetTree() {
            var sb = new StringBuilder(new String(' ', _lineWidth));
            GetTree(sb, RootNode, _lineWidth / 2, 0);
            return sb.ToString();
        }

        private void GetTree(StringBuilder sb, TreeNode<uint> currentNode, int x, int row) {
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
    }

    public class TreeNode<T> {
        public TreeNode<T> LeftNode, RightNode;
        public T Data;
    }
}
