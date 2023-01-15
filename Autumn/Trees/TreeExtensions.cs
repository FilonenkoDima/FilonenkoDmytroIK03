using System.Text;

namespace Trees
{
    public static class TreeExtensions
    {
        public static ITreeNode Successor(this IBinaryTree tree, ITreeNode node)
        {
            if (!tree.IsNull(node.RightChild))
            {
                var minimumSearcher = TreeMinimumSearcherFactory.Create<ITreeNode>(tree, SearchMethod.Recursive);
                return minimumSearcher.Minimum(node.RightChild);
            }

            var parent = node.ParentNode;
            while (parent != null && !tree.IsNull(parent) && node == parent.RightChild)
            {
                node = parent;
                parent = parent.ParentNode;
            }

            return parent;
        }

        public static ITreeNode Predecessor(this IBinaryTree tree, ITreeNode node)
        {
            if (!tree.IsNull(node.LeftChild))
            {
                return TreeMaximumSearcherFactory.Create(tree).Maximum(node.LeftChild);
            }

            var parent = node.ParentNode;
            while (parent != null && !tree.IsNull(parent) && node == parent.LeftChild)
            {
                node = parent;
                parent = parent.ParentNode;
            }

            return parent;
        }

        public static void Insert(this IBinaryTree tree, ITreeNode nodeToInsert)
        {
            var previousNode = tree.NullNode;
            var currentNode = tree.Root;
            while (!tree.IsNull(currentNode))
            {
                previousNode = currentNode;
                currentNode = nodeToInsert.Value.ToString().CompareTo(currentNode.Value.ToString()) == -1 //tree.KeySelector(nodeToInsert.Value) < tree.KeySelector(currentNode.Value) 
                    ? currentNode.LeftChild
                    : currentNode.RightChild;
            }

            nodeToInsert.SetParent(previousNode);
            if (tree.IsNull(previousNode))
            {
                tree.Root = nodeToInsert;
            }
            else if (nodeToInsert.Value.ToString().CompareTo(previousNode.Value.ToString()) == -1)
            {
                previousNode.LeftChild = nodeToInsert;
            }
            else
            {
                previousNode.RightChild = nodeToInsert;
            }

            nodeToInsert.LeftChild = tree.NullNode;
            nodeToInsert.RightChild = tree.NullNode;
        }

        public static string GetBinaryTreeString(this IBinaryTree tree)
        {
            var stringBuilder = new StringBuilder();
            var preorderWalker = new PreorderTreeWalker(tree);
            preorderWalker.Walk(node =>
            {
                string nodeStr = string.Empty;
                if (tree.IsNull(node.ParentNode))
                {
                    nodeStr = "NIL => ";
                }
                else
                {
                    nodeStr = $"{node.ParentNode.Value.ToString()} => ";
                }

                nodeStr += $"{node.Value.ToString()}  ";

                if (tree.IsNull(node.LeftChild))
                {
                    nodeStr += "Left: NIL  ";
                }
                else
                {
                    nodeStr +=
                        $"Left: {node.LeftChild.Value.ToString()}  ";
                }

                if (tree.IsNull(node.RightChild))
                {
                    nodeStr += "Right: NIL  ";
                }
                else
                {
                    nodeStr +=
                        $"Right: {node.RightChild.Value.ToString()}  ";
                }

                stringBuilder.AppendLine(nodeStr);
            });
            return stringBuilder.ToString();
        }
    }
}