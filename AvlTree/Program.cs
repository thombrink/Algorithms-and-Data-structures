using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree {
    class Program {
        static void Main(string[] args) {
            //http://stackoverflow.com/questions/3955680/how-to-check-if-my-avl-tree-implementation-is-correct

            var arrtest = new int[] { 1, 5, 7, 4, 8, 2, 6 };

            var arr8a = new int[] { 20, 4, 8 };
            var arr8b = new int[] { 20, 4, 26, 3, 9, 8 };
            var arr8c = new int[] { 20, 4, 26, 3, 21, 9, 30, 2, 7, 11, 8 };

            var tree = new AvlTree<int>();
            foreach (var i in arr8c) {
                tree.Add(i);
            }

            tree.Print();

            Console.ReadKey();
        }
    }

    class AvlTree<T> where T : IComparable<T> {
        public TreeNode<T> RootNode { get; set; }

        public void Add(T data) {
            RootNode = Add(RootNode, data);

            /*TreeNode<T> previousNode = null;
            TreeNode<T> currentNode = RootNode;
            bool leftSide = false;


            while(currentNode != null) {
                previousNode = currentNode;

                if (currentNode.Data.CompareTo(data) > 0) {
                    previousNode.LeftChildCount++;
                    currentNode = currentNode.LeftNode;
                    leftSide = true;
                }
                else {
                    previousNode.RightChildCount++;
                    currentNode = currentNode.RightNode;
                    leftSide = false;
                }

                //FindTreeNode(RootNode, value);
            }

            currentNode = new TreeNode<T>(previousNode, data, !leftSide);
            if (leftSide) {
                previousNode.LeftNode = currentNode;
                
            } else {
                previousNode.RightNode = currentNode;
            }

            if(Math.Abs(previousNode.LeftChildCount - previousNode.RightChildCount) > 1) {
                Console.WriteLine("Stop! Wait a minute");
            }

            Console.WriteLine("Hoi!");*/
        }

        public TreeNode<T> Add(TreeNode<T> currentNode, T data) {
            if (currentNode == null) {
                return new TreeNode<T>(data);
            }

            bool childGoneRight = false;

            if (currentNode.Data.CompareTo(data) > 0) {
                currentNode.LeftNode = Add(currentNode.LeftNode, data);
                currentNode.LeftChildCount++;
            }
            else {
                childGoneRight = true;

                currentNode.RightNode = Add(currentNode.RightNode, data);
                currentNode.RightChildCount++;
            }

            if (Math.Abs(currentNode.LeftChildCount - currentNode.RightChildCount) > 1) {
                //Console.WriteLine("Stop! Wait a minute, I'm unbalanced!");

                // left left
                if (!childGoneRight && currentNode.LeftNode.Data.CompareTo(data) > 0) {
                    #region Normal rotation
                    var moveUpNode = currentNode.LeftNode;

                    currentNode.LeftNode = moveUpNode.RightNode;
                    currentNode.LeftChildCount = moveUpNode.RightChildCount;//correct?

                    moveUpNode.RightNode = currentNode;
                    moveUpNode.RightChildCount = currentNode.RightChildCount + 1;

                    currentNode = moveUpNode;
                    #endregion
                }
                //left right
                else if (!childGoneRight) {
                    #region Child rotation
                    var moveUpChildNode = currentNode.LeftNode.RightNode;

                    if (moveUpChildNode != null) {
                        // disconnect the move up node
                        currentNode.LeftNode.RightNode = moveUpChildNode.LeftNode;
                        currentNode.LeftNode.RightChildCount = moveUpChildNode.LeftChildCount;//correct?

                        moveUpChildNode.LeftNode = currentNode.LeftNode;
                        moveUpChildNode.LeftChildCount = currentNode.LeftNode.LeftChildCount + 1;

                        currentNode.LeftNode = moveUpChildNode;
                    }
                    #endregion
                    #region Normal rotation
                    var moveUpNode = currentNode.LeftNode;

                    currentNode.LeftNode = moveUpNode.RightNode;
                    currentNode.LeftChildCount = moveUpNode.RightChildCount;//correct?

                    moveUpNode.RightNode = currentNode;
                    moveUpNode.RightChildCount = currentNode.RightChildCount + 1;

                    currentNode = moveUpNode;
                    #endregion
                }
                // right right
                else if (childGoneRight && currentNode.RightNode.Data.CompareTo(data) < 0) {
                    #region Normal rotation
                    var moveUpNode = currentNode.RightNode;

                    currentNode.RightNode = moveUpNode.LeftNode;
                    currentNode.RightChildCount = moveUpNode.LeftChildCount;//correct?

                    moveUpNode.LeftNode = currentNode;
                    moveUpNode.LeftChildCount = currentNode.LeftChildCount + 1;

                    currentNode = moveUpNode;
                    #endregion
                }
                // right left
                else {
                    #region Child rotation
                    var moveUpChildNode = currentNode.RightNode.LeftNode;

                    if (moveUpChildNode != null) {
                        // disconnect the move up node
                        currentNode.RightNode.LeftNode = moveUpChildNode.RightNode;
                        currentNode.RightNode.LeftChildCount = moveUpChildNode.RightChildCount;//correct?

                        moveUpChildNode.RightNode = currentNode.RightNode;
                        moveUpChildNode.RightChildCount = currentNode.RightNode.RightChildCount + 1;

                        currentNode.RightNode = moveUpChildNode;
                    }
                    #endregion
                    #region Normal rotation
                    var moveUpNode = currentNode.RightNode;

                    currentNode.RightNode = moveUpNode.LeftNode;
                    currentNode.RightChildCount = moveUpNode.LeftChildCount;//correct?

                    moveUpNode.LeftNode = currentNode;
                    moveUpNode.LeftChildCount = currentNode.LeftChildCount + 1;

                    currentNode = moveUpNode;
                    #endregion
                }
            }

            return currentNode;
        }

        class NodeInfo {
            public TreeNode<T> Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public void Print(TreeNode<T> root = null, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2) {
            if (root == null) root = RootNode; //return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++) {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString() };//next.Data.ToString(textFormat)
                if (level < last.Count) {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0) {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.LeftNode) {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.LeftNode ?? next.RightNode;
                for (; next == null; item = item.Parent) {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null) {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null) {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left) {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.RightNode;
                    }
                    else {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private void Print(string s, int top, int left, int right = -1) {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }
    }

    public class TreeNode<T> where T : IComparable<T> {
        public TreeNode<T> ParentNode, LeftNode, RightNode;
        public T Data;
        public int LeftChildCount;
        public int RightChildCount;
        //public int ChildCount;

        public TreeNode() { }

        public TreeNode(T data) {//TreeNode<T> parentNode, 
            //ParentNode = parentNode;
            Data = data;
        }
    }
}
