using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TreeLab5
{
    public class Tree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }

        public Tree(Node<T> root)
        {
            Root = root;
        }

        public Node<T> FindMin(Node<T>? startWithNode = null)
        {
            startWithNode = startWithNode ?? Root;
            if (startWithNode.LeftNode != null)
            {
                return FindMin(startWithNode.LeftNode);
            }
            return startWithNode;

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

        public Node<T>? DeleteLeafNode(Node<T> node)
        {
            return (node.ParentNode.LeftNode == node)
                ? (node.ParentNode.LeftNode = null)
                : (node.ParentNode.RightNode == node)
                    ? (node.ParentNode.RightNode = null)
                    : null;
        }

        public Node<T>? DeleteOneChildNode(Node<T> node)
        {
            return (node.ParentNode.LeftNode == node)
                ? node.LeftNode == null
                    ? node.ParentNode.LeftNode = node.RightNode
                    : node.ParentNode.LeftNode = node.LeftNode
                : node.ParentNode.RightNode == node
                    ? node.LeftNode == null
                        ? node.ParentNode.RightNode = node.RightNode
                        : node.ParentNode.RightNode = node.LeftNode
                    : null;
        }

        public Node<T>? DeleteNode(Node<T>? startWithNode, Node<T> nodeToDelete)
        {
            if (startWithNode == null)
                return startWithNode;

            if (nodeToDelete.Data.CompareTo(startWithNode.Data) < 0)
            {
                startWithNode.LeftNode = DeleteNode(startWithNode.LeftNode, nodeToDelete);
            }
            else if (nodeToDelete.Data.CompareTo(startWithNode.Data) > 0)
            {
                startWithNode.RightNode = DeleteNode(startWithNode.RightNode, nodeToDelete);
            }
            else
            {
                if (startWithNode.LeftNode == null)
                {
                    return startWithNode.LeftNode;
                }
                else if (startWithNode.RightNode == null)
                {
                    return startWithNode.RightNode;
                }

                Node<T> minRigthNode = FindMin(Root.RightNode);
                Root = minRigthNode;
                Root.RightNode = DeleteNode(Root.RightNode, minRigthNode);

            }
            return Root;
        }

        public void printBT(string prefix, Node<T>? node, bool isLeft)
        {
            if(node != null )
            {
                Console.Write(prefix);

                Console.Write(isLeft? "├──" : "└──" );

                Console.WriteLine(node.Data);

                printBT(prefix + (isLeft? "│   " : "    "), node.LeftNode, true);
                printBT(prefix + (isLeft? "│   " : "    "), node.RightNode, false);
            }
        }

        public void printBT(Node<T> node)
        {
            printBT("", node, false);
        }

public int NodeHeight(Node<T>? startWithNode)
{
    int left, right, height;
    height = 0;
    if (startWithNode != null)
    {
        left = NodeHeight(startWithNode.LeftNode);
        right = NodeHeight(startWithNode.RightNode);
        height = (left > right ? left : right) + 1;
    }
    return height;
}


        public int CountNodesTree(Node<T>? startWithNode)
        {
            if (startWithNode == null)
                return 0;

            int leftCount, rightCount;

            leftCount = CountNodesTree(startWithNode.LeftNode);
            rightCount = CountNodesTree(startWithNode.RightNode);

            return leftCount + rightCount + 1;
        }


        public Node<T> RotateRight(Node<T> p) 
        {
            Node<T>? q = p.LeftNode;
            if (q == null) return p;
            p.LeftNode = q.RightNode;
            q.RightNode = p;
            return q;
        }

        public Node<T> RotateLeft(Node<T> q)
        {
            Node<T>? p = q.RightNode;
            if (p == null) return q;
            q.RightNode = p.LeftNode;
            p.LeftNode = q;
            return p;
        }

        public Node<T> InsertNode(Node<T> nodeToInsert, Node<T>? startWithNode)
        {
            if (startWithNode == null)
            {
                return nodeToInsert;
            }

            
            if (nodeToInsert.Data.CompareTo(startWithNode.Data) < 0)
            {
                startWithNode.LeftNode = InsertNode(nodeToInsert, startWithNode.LeftNode);
            }
            else
            {
                startWithNode.RightNode = InsertNode(nodeToInsert, startWithNode.RightNode);
            }
            return startWithNode;
        }


        public Node<T> InsertRoot(Node<T> nodeToInsert, Node<T>? startWithNode = null)
        {
            if (startWithNode == null) return nodeToInsert;
            if (nodeToInsert.Data.CompareTo(startWithNode.Data) < 0)
            {
                startWithNode.LeftNode = InsertRoot(nodeToInsert, startWithNode.LeftNode);
                return Root = RotateRight(startWithNode);
            }
            else
            {
                startWithNode.RightNode = InsertRoot(nodeToInsert, startWithNode.RightNode);
                return Root = RotateLeft(startWithNode);
            }
        }


public Node<T> RandomInsert(Node<T> nodeToInsert, Node<T>? startWithNode = null)
{
    Random rnd = new Random();
    if (startWithNode == null) return nodeToInsert;
    if (rnd.Next(0, CountNodesTree(startWithNode) + 1) == 1)
    {
        return InsertRoot(nodeToInsert, startWithNode);
    }
    if (nodeToInsert.Data.CompareTo(startWithNode.Data) < 0)
    {
        return InsertNode(nodeToInsert, startWithNode.LeftNode);
    }
    else
    {
        return InsertNode(nodeToInsert, startWithNode.RightNode);
    }
}

        public int GetSumLengthPathToEvens(Node<int> startWithNode, int currentLength = 0)
        {
            if (startWithNode == null) return 0;

            int left, right;

            left = GetSumLengthPathToEvens(startWithNode.LeftNode, currentLength + 1);
            right = GetSumLengthPathToEvens(startWithNode.RightNode, currentLength + 1);

            if (startWithNode.Data % 2 == 0)
            {
                return left + right + currentLength;
            }
            return left + right;
        }
    }



    public class Node<T> where T : IComparable
    {
        public T Data { get; set; }
        public Node<T>? LeftNode { get; set; }
        public Node<T>? RightNode { get; set; }
        public Node<T> ParentNode { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }


}
