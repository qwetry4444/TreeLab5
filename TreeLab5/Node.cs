using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLab5
{
    public class Tree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }

        public Node<T> InsertNode(Node<T> node, Node<T> currentNode)
        {
            if (Root == null)
            {
                return Root = node;
            }

            currentNode = currentNode ?? Root;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? (currentNode.LeftNode == null)
                        ? (currentNode.LeftNode = node)
                        : InsertNode(node, currentNode.LeftNode)
                    : (currentNode.RightNode == null)
                        ? (currentNode.RightNode = node)
                        : InsertNode(node, currentNode.RightNode);
        }

        public Node<T>? FindNode(T data, Node<T>? startWithNode = null)
        {
            startWithNode = startWithNode ?? Root;
            int result;
            return (result = startWithNode.Data.CompareTo(data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
            
        }
    }

    public class Node<T> where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> ParentNode { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }


}
