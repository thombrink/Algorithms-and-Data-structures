using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree {
    class Program {
        static void Main(string[] args) {
            var charTree = new GeneralTree<char>();
            var k = new TreeNode<char> { Data = 'k' };
            var j = new TreeNode<char> { Data = 'j', FirstChild = k };
            var i = new TreeNode<char> { Data = 'i', NextSibling = j };
            var e = new TreeNode<char> { Data = 'e', FirstChild = i };
            var h = new TreeNode<char> { Data = 'h' };
            var d = new TreeNode<char> { Data = 'd', FirstChild = h, NextSibling = e };
            var c = new TreeNode<char> { Data = 'c', NextSibling = d };
            var g = new TreeNode<char> { Data = 'g' };
            var f = new TreeNode<char> { Data = 'f', NextSibling = g };
            var b = new TreeNode<char> { Data = 'b', FirstChild = f, NextSibling = c };
            var a = new TreeNode<char> { Data = 'a', FirstChild = b };
            charTree.RootNode = a;

            Console.WriteLine(charTree.PrintPreOrder1());
            Console.WriteLine(charTree.PrintPreOrder2(charTree.RootNode));
            Console.WriteLine(charTree.PrintPreOrder2());
            Console.WriteLine(charTree.GetSize());

            //charTree.AddFistChild('b');
            //charTree.AddFistChild('f');
            //charTree.AddFistChild('b');
            //charTree.AddFistChild('b');
            //charTree.AddFistChild('b');

            Console.ReadKey();
        }
    }

    public class GeneralTree<T> {
        //private TreeNode<T> _rootNode, _currentNode;
        public TreeNode<T> RootNode { get; set; } = new TreeNode<T>();

        public GeneralTree() {
            //_currentNode = new TreeNode<T>();
            //_rootNode = new TreeNode<T>() { NextSibling = _currentNode };
        }

        /*public TreeNode<T> AddFistChild(T data) {
            var tempNode = _currentNode;
            _currentNode.FirstChild = new TreeNode<T> { Data = data };
            //return _currentNode = _currentNode.FirstChild;
            return _currentNode = _currentNode.FirstChild;
        }

        public TreeNode<T> AddNextSibling(T data) {
            var tempNode = _currentNode;
            _currentNode.NextSibling = new TreeNode<T> { Data = data };
            _currentNode = _currentNode.NextSibling;
            return tempNode;
        }*/

        public string PrintPreOrder1() {
            var sb = new StringBuilder(RootNode.Data.ToString());

            var nextStack = new Stack<TreeNode<T>>();

            TreeNode<T> currentNode = RootNode;
            TreeNode<T> nextNode;
            while ((nextNode = currentNode?.FirstChild ?? currentNode?.NextSibling ?? (nextStack.Any() ? nextStack.Pop() : null)) != null) {
                sb.Append(nextNode.Data.ToString());

                if(currentNode.FirstChild != null && currentNode.NextSibling != null) {
                    nextStack.Push(currentNode.NextSibling);
                }

                currentNode = nextNode;
            }

            return sb.ToString();
        }

        public string PrintPreOrder2() {
            return PrintPreOrder2(RootNode);
        }

        public string PrintPreOrder2(TreeNode<T> currentNode) {
            var result = currentNode.Data.ToString();

            if (currentNode.FirstChild != null) {
                result += PrintPreOrder2(currentNode.FirstChild);
            }

            if (currentNode.NextSibling != null) {
                result += PrintPreOrder2(currentNode.NextSibling);
            }

            return result;
        }

        public int GetSize() {
            return GetSize(RootNode);
        }

        public int GetSize(TreeNode<T> currentNode) {
            var result = 1;

            if (currentNode.FirstChild != null) {
                result += GetSize(currentNode.FirstChild);
            }

            if (currentNode.NextSibling != null) {
                result += GetSize(currentNode.NextSibling);
            }

            return result;
        }
    }

    public class TreeNode<T> {
        //private TreeNode<T> _firstChild, _nextSibling;
        //private T _data;
        public TreeNode<T> FirstChild, NextSibling;
        public T Data;

        /*public TreeNode(TreeNode<T> firstChild, TreeNode<T> nextSibling, T data) {
            _firstChild = firstChild;
            _nextSibling = nextSibling;
            _data = data;
        }*/
    }
}
