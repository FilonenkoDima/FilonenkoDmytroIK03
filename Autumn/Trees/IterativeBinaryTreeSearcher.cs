using System;

namespace Trees
{
    public class IterativeBinaryTreeSearcher : ITreeSearcher
    {
        private readonly IBinaryTree _tree;

        public IterativeBinaryTreeSearcher(IBinaryTree tree)
        {
            _tree = tree;
        }
        
        public ITreeNode Search(object key)
        {
            return _tree == null ? default : _Search(_tree.Root, key);
        }

        private ITreeNode _Search(ITreeNode node, object key)
        {
            while (!_tree.IsNull(node) && key.ToString() != node.Value.ToString())
            {
                node = key.ToString().CompareTo(node.Value.ToString()) == -1 ? node.LeftChild : node.RightChild;
            }

            return node;
        }
    }
}