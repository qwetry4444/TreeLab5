
namespace TreeLab5
{
    class Program
    {
        public static void Main()
        {
            //Node<int> node1 = new Node<int>(1);
            //Node<int> node2 = new Node<int>(2);
            //Node<int> node3 = new Node<int>(3);
            //Node<int> node4 = new Node<int>(4);
            //Node<int> node5 = new Node<int>(50000);

            Random rnd = new Random();

            AVLNode<int> node1 = new AVLNode<int>(1);
            AVLNode<int> node2 = new AVLNode<int>(2);
            AVLNode<int> node3 = new AVLNode<int>(3);
            AVLNode<int> node4 = new AVLNode<int>(0);
            AVLTree<int> AVLTree = new AVLTree<int>(node1);
            AVLTree.PrintBT(AVLTree.Root);

            for (int i = 0; i < 20; i++)
            {
                AVLTree.AVLInsert(new AVLNode<int>(i), AVLTree.Root);
            }

            AVLTree.PrintBT(AVLTree.Root);
            //Console.WriteLine((AVLTree).CountNodesTree((Node<int>)AVLTree.Root));

            //Console.WriteLine(AVLTree.Root.LeftNode.Data);
            //Console.WriteLine(AVLTree.Root.RightNode.Data);

            //for (int countNodes = 1; countNodes < 6; countNodes++)
            //{
            //    Tree<int> tree = new Tree<int>(new Node<int>(rnd.Next(0, countNodes * 10000)));

            //    for (int i = 2; i < countNodes * 10000; i++)
            //    {
            //        tree.InsertNode(new Node<int>(rnd.Next(0, 10000)), tree.Root);
            //    }

            //    Console.WriteLine($"Количество вершин: {countNodes * 10000} Высота дерева: {tree.NodeHeight(tree.Root)}");
            //}
            //Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            //for (int countNodes = 1; countNodes < 6; countNodes++)
            //{
            //    Tree<int> tree = new Tree<int>(new Node<int>(rnd.Next(0, 10000)));

            //    for (int i = 2; i < countNodes * 10000; i++)
            //    {
            //        tree.RandomInsert(new Node<int>(rnd.Next(0, countNodes * 10000)), tree.Root);
            //    }

            //    Console.WriteLine($"Количество вершин: {countNodes * 10000} Высота дерева: {tree.NodeHeight(tree.Root)}");
            //}

            //Tree<int> tree = new Tree<int>(new Node<int>(5));
            //////tree.InsertRoot(node1, tree.Root);
            ////tree.InsertRoot(new Node<int>(1), tree.Root);
            ////tree.InsertNode(new Node<int>(11), tree.Root);
            ////tree.InsertNode(new Node<int>(6), tree.Root);
            ////tree.InsertNode(new Node<int>(-100), tree.Root);

            ////tree.printBT(tree.Root);

            //for (int i = 2; i < 10; i++)
            //{
            //    tree.InsertNode(new Node<int>(i), tree.Root);
            //}
            //tree.printBT(tree.Root);
            //Console.WriteLine(tree.GetSumLengthPathToEvens(tree.Root));

            //Console.WriteLine($"Количество вершин: {20000} Высота дерева: {tree.NodeHeight(tree.Root)}");



        }
    }
}