using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLab5
{
    public class AVLTree<T> : Tree<T> where T : IComparable
    {
        public AVLTree(AVLNode<T> root) : base(root)
        {
            Root = root;
        }

        public new AVLNode<T> Root { get; set; }


        public AVLNode<T> RotateRight(AVLNode<T> p)
        {
            AVLNode<T>? q = p.LeftNode;
            if (q == null) return p;
            p.LeftNode = q.RightNode;
            q.RightNode = p;
            return q;
        }

        public AVLNode<T> RotateLeft(AVLNode<T> q)
        {
            AVLNode<T>? p = q.RightNode;
            if (p == null) return q;
            q.RightNode = p.LeftNode;
            p.LeftNode = q;
            return p;
        }

        public AVLNode<T> Balance(AVLNode<T> node)
        {
            node.FixHeight();
            if (node.BalanceFactor() == 2)
            {
                if (node.RightNode.BalanceFactor() < 0)
                {

                    node.RightNode = RotateRight(node.RightNode);
                }
                return RotateLeft(node);
            }

            if (node.BalanceFactor() == -2)
            {
                if (node.LeftNode.BalanceFactor() > 0)
                {
                    node.LeftNode = RotateLeft(node.LeftNode);
                }
                return RotateRight(node);
            }
            return node;
        }

        public AVLNode<T> AVLInsert(AVLNode<T> nodeToInsert, AVLNode<T> startWithNode)
        {
            if (startWithNode == null) return nodeToInsert;
            if (nodeToInsert.Data.CompareTo(startWithNode.Data) < 0)
            {
                startWithNode.LeftNode = AVLInsert(nodeToInsert, startWithNode.LeftNode);
            }
            else
            {
                startWithNode.RightNode = AVLInsert(nodeToInsert, startWithNode.RightNode);
            }
            return Balance(startWithNode);
        }

        public void PrintBT(string prefix, AVLNode<T>? node, bool isLeft)
        {
            if (node != null)
            {
                Console.Write(prefix);

                Console.Write(isLeft ? "├──" : "└──");

                Console.WriteLine(node.Data);

                PrintBT(prefix + (isLeft ? "│   " : "    "), node.LeftNode, true);
                PrintBT(prefix + (isLeft ? "│   " : "    "), node.RightNode, false);
            }
        }

        public void PrintBT(AVLNode<T> node)
        {
            PrintBT("", node, false);
        }
    }


    public class AVLNode<T>(T data) : Node<T>(data) where T : IComparable
    {
        public int Height { get; set; } = 1;
        public new AVLNode<T> LeftNode { get; set; }
        public new AVLNode<T> RightNode { get; set; }

        public int GetHeight(AVLNode<T>? node)
        {
            return node != null ? node.Height : 0;
        }

        public int BalanceFactor()
        {
            return GetHeight(RightNode) - GetHeight(LeftNode);
        }

        public void FixHeight()
        {
            int heightLeft =  GetHeight(LeftNode);
            int heightRight = GetHeight(RightNode);
            Height = (heightLeft > heightRight ? heightLeft : heightRight) + 1;
        }

        
    }
}
