using Trees;
using Client;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tests
{
    [ExcludeFromCodeCoverage]
    public class UnitTest1
    {
        [Fact]
        public void EnumarateTest()
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
            n18.SetLeft(n14);
            n18.SetRight(n19);
            n11.SetLeft(n9);
            n11.SetRight(n18);
            n7.SetRight(n11);
            tree.SetRoot(n7);

            Assert.NotEmpty(tree.Enumerate(0, 50));
        }

        [Fact]
        public void SearchTest()
        {
            var tree = DekstopTest.CreateTree();

            var resultIter = tree.CreateSearcher(SearchMethod.Iterative, 3).Value;
            var resultRecur = tree.CreateSearcher(SearchMethod.Recursive, 3).Value;
            //var resultException = tree.CreateSearcher(default, 3).Value;

            Assert.Equal("3", resultIter.ToString());
            Assert.Equal("3", resultRecur.ToString());
            //Assert.Throws<ArgumentOutOfRangeException> (() => resultException);
        }

        [Fact]
        public void FindMaximumTest()
        {
            var tree = DekstopTest.CreateTree();

            var resultIter = tree.CreateMaximumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Iterative).Value;
            var resultRecur = tree.CreateMaximumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Recursive).Value;

            Assert.Equal("22", resultIter.ToString());
            Assert.Equal("22", resultRecur.ToString());
        }

        [Fact]
        public void FindMinimumTest()
        {
            var tree = DekstopTest.CreateTree();

            var resultIter = tree.CreateMinimumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Iterative).Value;
            var resultRecur = tree.CreateMinimumSearcher(tree.Root as BinaryTreeNode<int>, SearchMethod.Recursive).Value;

            Assert.Equal("2", resultIter.ToString());
            Assert.Equal("2", resultRecur.ToString());
        }

        [Fact]
        public void FindPredecesorTest()
        {
            var tree = DekstopTest.CreateTree();

            var result = tree.FindPredecessor(tree.CreateSearcher(SearchMethod.Recursive, 3)).Value;

            Assert.Equal("2", result.ToString());
        }

        [Fact]
        public void FindSuccessorTest()
        {
            var tree = DekstopTest.CreateTree();

            var result = tree.FindSuccessor(tree.CreateSearcher(SearchMethod.Recursive, 3)).Value;

            Assert.Equal("4", result.ToString());
        }

        [Fact]
        public void InsertTest()
        {
            var tree = DekstopTest.CreateTree();

            tree.Insert(tree.CreateNode(5));

            Assert.Equal("0", tree.CreateSearcher(SearchMethod.Recursive, 5).LeftChild.Value.ToString());
            Assert.Equal("0", tree.CreateSearcher(SearchMethod.Recursive, 5).RightChild.Value.ToString());
        }

        [Fact]
        public void NodeToStringTest()
        {
            var tree = DekstopTest.CreateTree();

            var result = tree.CreateSearcher(SearchMethod.Recursive, 3).ToString();

            Assert.Equal(result, "Data: 3, Left: True, Right: False, Parent: True");
        }

        [Fact]
        public void TreeToStringTest()
        {
            var expextedString =
@"NIL => 7  Left: 4  Right: 11  
7 => 4  Left: 3  Right: 6  
4 => 3  Left: 2  Right: NIL  
3 => 2  Left: NIL  Right: NIL  
4 => 6  Left: NIL  Right: NIL  
7 => 11  Left: 9  Right: 18  
11 => 9  Left: NIL  Right: NIL  
11 => 18  Left: 14  Right: 19  
18 => 14  Left: 12  Right: 17  
14 => 12  Left: NIL  Right: NIL  
14 => 17  Left: NIL  Right: NIL  
18 => 19  Left: NIL  Right: 22  
19 => 22  Left: 20  Right: NIL  
22 => 20  Left: NIL  Right: NIL  
";
            var tree = DekstopTest.CreateTree();

            var result = tree.ToString();

            Assert.Equal(expextedString, result);
        }

        [Fact]
        public void IsNullNodeTest()
        {
            var tree = DekstopTest.CreateTree();

            var result = tree.IsNull(tree.Root);

            Assert.NotNull(result);
        }

        [Fact]
        public void CompareNode()
        {

            var tree = new BinaryTree<int>();
            var n = tree.CreateNode(3);

            var result = n.CompareTo(3);

            Assert.Equal(0, result);
        }
    }
}