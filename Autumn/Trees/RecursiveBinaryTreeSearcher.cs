using System;

namespace Trees
{
    public class RecursiveBinaryTreeSearcher : ITreeSearcher
    {
        private readonly IBinaryTree _tree;

        public RecursiveBinaryTreeSearcher(IBinaryTree tree)
        {
            _tree = tree;
        }

        public ITreeNode Search(object key)
        {
            return _tree == null ? default : _Search(_tree.Root, key);
        }

        private ITreeNode _Search(ITreeNode node, object key)
        {
            if (_tree.IsNull(node) || key.ToString().CompareTo(node.Value.ToString()) == 0)
            {
                return node;
            }

            return _Search(key.ToString().CompareTo(node.ToString()) == -1 ? node.LeftChild : node.RightChild, key);
        }
    }
}