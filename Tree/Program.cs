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
            charTree.Root = a;

            charTree.PrintPreOrder();
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
        public TreeNode<T> Root;

        public void PrintPreOrder() {
            Root.PrintPreOrder();
        }

        public int GetSize() {
            return Root.GetSize();
        }
    }

    public class TreeNode<T> {
        public TreeNode<T> FirstChild;
        public TreeNode<T> NextSibling;

        public T Data;

        public TreeNode() {
        }

        public TreeNode(T data) {
            Data = data;
        }

        public void PrintPreOrder() {
            Console.Write(this);
            FirstChild?.PrintPreOrder();
            NextSibling?.PrintPreOrder();
        }

        public override string ToString() {
            return Data.ToString();
        }

        public int GetSize() {
            int size = 1;
            if (FirstChild != null) size += FirstChild.GetSize();
            if (NextSibling != null) size += NextSibling.GetSize();
            return size;
        }
    }
}
