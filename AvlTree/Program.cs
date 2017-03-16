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

            var arr15a = new int[] { 20, 4, 15 };
            var arr15b = new int[] { 20, 4, 26, 3, 9, 15 };
            var arr15c = new int[] { 20, 4, 26, 3, 21, 9, 30, 2, 7, 11, 15 };

            var arr8a = new int[] { 20, 4, 8 };
            var arr8b = new int[] { 20, 4, 26, 3, 9, 8 };
            var arr8c = new int[] { 20, 4, 26, 3, 21, 9, 30, 2, 7, 11, 8 };

            var tree = new AvlTree<int>();
            foreach (var i in arr15c) {
                tree.Add(i);
                tree.Print();
            }                

            Console.ReadKey();
        }
    }

    class AvlTree<T> where T : IComparable<T> {
        public TreeNode<T> RootNode { get; set; }
        public Direction Direction { get; set; } 

        public void Add(T data) {
            RootNode = Add(RootNode, data);

            Direction = Direction.None;

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

        private TreeNode<T> Add(TreeNode<T> currentNode, T data) {
            if (currentNode == null) {
                return new TreeNode<T>(data);
            }

            bool childGoneRight = false;

            if (currentNode.Data.CompareTo(data) > 0) {
                currentNode.LeftNode = Add(currentNode.LeftNode, data);

                IncreseHeight(currentNode, Direction.Left);
                //currentNode.LeftHeight++;
            }
            else {
                childGoneRight = true;

                currentNode.RightNode = Add(currentNode.RightNode, data);

                IncreseHeight(currentNode, Direction.Right);
                //currentNode.RightHeight++;
            }

            if (Math.Abs((currentNode.LeftNode?.Height ?? 0) - (currentNode.RightNode?.Height ?? 0)) > 1) {
            //if (Math.Abs(currentNode.LeftHeight - currentNode.RightHeight) > 1) {
                    //Console.WriteLine("Stop! Wait a minute, I'm unbalanced!");

                    // left left
                    if (!childGoneRight && currentNode.LeftNode.Data.CompareTo(data) > 0) {
                    #region Normal rotation
                    var moveUpNode = currentNode.LeftNode;

                    currentNode.LeftNode = moveUpNode.RightNode;
                    currentNode.LeftHeight = moveUpNode.RightHeight;

                    moveUpNode.RightNode = currentNode;
                    moveUpNode.RightHeight = currentNode.RightHeight + 1;

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
                        currentNode.LeftNode.RightHeight = moveUpChildNode.LeftHeight;

                        moveUpChildNode.LeftNode = currentNode.LeftNode;
                        moveUpChildNode.LeftHeight = currentNode.LeftNode.LeftHeight + 1;

                        currentNode.LeftNode = moveUpChildNode;
                    }
                    #endregion
                    #region Normal rotation
                    var moveUpNode = currentNode.LeftNode;

                    currentNode.LeftNode = moveUpNode.RightNode;
                    currentNode.LeftHeight = moveUpNode.RightHeight;

                    moveUpNode.RightNode = currentNode;
                    moveUpNode.RightHeight = currentNode.RightHeight + 1;

                    currentNode = moveUpNode;
                    #endregion
                }
                // right right
                else if (childGoneRight && currentNode.RightNode.Data.CompareTo(data) < 0) {
                    #region Normal rotation
                    var moveUpNode = currentNode.RightNode;

                    currentNode.RightNode = moveUpNode.LeftNode;
                    currentNode.RightHeight = moveUpNode.LeftHeight;

                    moveUpNode.LeftNode = currentNode;
                    moveUpNode.LeftHeight = currentNode.LeftHeight + 1;

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
                        currentNode.RightNode.LeftHeight = moveUpChildNode.RightHeight;

                        moveUpChildNode.RightNode = currentNode.RightNode;
                        moveUpChildNode.RightHeight = currentNode.RightNode.RightHeight + 1;

                        currentNode.RightNode = moveUpChildNode;
                    }
                    #endregion
                    #region Normal rotation
                    var moveUpNode = currentNode.RightNode;

                    currentNode.RightNode = moveUpNode.LeftNode;
                    currentNode.RightHeight = moveUpNode.LeftHeight;

                    moveUpNode.LeftNode = currentNode;
                    moveUpNode.LeftHeight = currentNode.LeftHeight + 1;

                    currentNode = moveUpNode;
                    #endregion
                }
            }

            return currentNode;
        }

        private void IncreseHeight(TreeNode<T> node, Direction direction) {
            if (Direction == Direction.None) {
                Direction = direction;
            }

            if (Direction == direction) {
                if (Direction == Direction.Left) {
                    node.LeftHeight++;
                }
                else {
                    node.RightHeight++;
                }
            }
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

        class NodeInfo {
            public TreeNode<T> Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
    }

    public class TreeNode<T> where T : IComparable<T> {
        public TreeNode<T> LeftNode, RightNode;
        public T Data;
        /*public int Height { get {
                return 1 + Math.Max(Math.Max(LeftNode.LeftHeight, RightHeight), Math.Max(RightNode.LeftHeight, RightNode.RightHeight));
            }
        }*/
        public int Height {
            get {
                return 1 + Math.Max(LeftHeight, RightHeight);
            }
        }
        public int LeftHeight;
        public int RightHeight;
        //public int ChildCount;

        public TreeNode() { }

        public TreeNode(T data) {//TreeNode<T> parentNode, 
            //ParentNode = parentNode;
            Data = data;
        }
    }

    public enum Direction {
        None,
        Left,
        Right
    }
}
