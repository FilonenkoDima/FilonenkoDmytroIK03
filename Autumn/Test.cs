using Trees;

namespace Client
{
    static public class DekstopTest
    {
 

        public static void Testing()
        {
            //Console.WriteLine("Create tree");
            //Console.WriteLine(CreateTree());
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
            //Console.WriteLine("Testing search. \nFinding node with value 3");
            ////TestSearch();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
            //Console.WriteLine("Finding maximum");
            ////FindMaximum();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
            //Console.WriteLine("Finding minimum");
            ////FindMinimum();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
            //Console.WriteLine("Finding Predecesor of node with value 3");
            ////FindPredecesor();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
            //Console.WriteLine("Finding Successor of node with value 3");
            ////FindSuccessor();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
            //Console.WriteLine("Insert node with value 5");
            ////Insert();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
            //Console.WriteLine("DekstopTest Enumerate");
            ////TestEnumerate();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ReadLine();
        }

        public static BinaryTree<int> CreateTree()
        {
            var tree = new BinaryTree<int>();
            var n2 = tree.CreateNode(2);
            var n3 = tree.CreateNode(3);
            var n4 = tree.CreateNode(4);
            var n6 = tree.CreateNode(6);
            var n7 = tree.CreateNode(7);
            var n11 = tree.CreateNode(11);
            var n9 = tree.CreateNode(9);
            var n18 = tree.CreateNode(18);
            var n12 = tree.CreateNode(12);
            var n14 = tree.CreateNode(14);
            var n17 = tree.CreateNode(17);
            var n19 = tree.CreateNode(19);
            var n22 = tree.CreateNode(22);
            var n20 = tree.CreateNode(20);

            n3.SetLeft(n2);
            n4.SetLeft(n3);
            n4.SetRight(n6);
            n7.SetLeft(n4);

            n22.SetLeft(n20);
            n19.SetRight(n22);
            n14.SetLeft(n12);
            n14.SetRight(n17);
            n18.SetLeft(n14);//
            n18.SetRight(n19);//
            n11.SetLeft(n9);//
            n11.SetRight(n18);//
            n7.SetRight(n11);//
            tree.SetRoot(n7);

            //Console.WriteLine(tree.ToString());
            return tree;
        }

        //public static void TestSearch()
        //{
        //    var tree = CreateTree();

        //    Console.WriteLine("Iterarive search");
        //    var iterativeSearcher = BinaryTreeSearcherFactory.Create(tree, SearchMethod.Iterative);
        //    var iterativeNode = iterativeSearcher.Search(3);
        //    Console.WriteLine(iterativeNode.ToString());

        //    Console.WriteLine("Recursive search");
        //    var recursiveSearcher = BinaryTreeSearcherFactory.Create(tree, SearchMethod.Recursive);
        //    var recursiveNode = recursiveSearcher.Search(3);
        //    Console.WriteLine(recursiveNode.ToString());


        //}

        //public static void FindMaximum()
        //{
        //    var tree = CreateTree();
        //    var node = tree.CreateMaximumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Recursive);
        //    Console.WriteLine("Recursive method\n\t" + node.ToString());
        //    node = tree.CreateMaximumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Iterative);
        //    Console.WriteLine("Iterative method\n\t" + node.ToString());
        //}

        //public static void FindMinimum()
        //{
        //    var tree = CreateTree();
        //    var node = tree.CreateMinimumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Recursive);
        //    Console.WriteLine("Recursive method\n\t" + node.ToString());
        //    node = tree.CreateMinimumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Iterative);
        //    Console.WriteLine("Iterative method\n\t" + node.ToString());
        //}

        //public static void FindPredecesor()
        //{
        //    var tree = CreateTree();
        //    var successor = tree.FindPredecessor(tree.CreateSearcher(SearchMethod.Recursive, 3));
        //    Console.WriteLine("Predecessor:\n\t" + successor.ToString());
        //}

        //public static void FindSuccessor()
        //{
        //    var tree = CreateTree();
        //    var successor = tree.FindSuccessor(tree.CreateSearcher(SearchMethod.Recursive, 3));
        //    Console.WriteLine("Successor:\n\t" + successor.ToString());
        //}

        //public static void Insert()
        //{
        //    var tree = CreateTree();
        //    Console.WriteLine(tree.ToString());
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    var node = tree.CreateNode(5);
        //    tree.Insert(node);
        //    Console.WriteLine(tree.ToString());
        //}


        //public static void TestEnumerate()
        //{
        //    var tree = CreateTree();
        //    var output = tree.Enumerate(7, 17);
        //    foreach (var item in output)
        //        Console.WriteLine(item.ToString());
        //}

    }
}