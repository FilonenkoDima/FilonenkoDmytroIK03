using System;
using System.Threading.Tasks;

namespace Trees
{
    public class PreorderTreeWalker : ITreeWalker
    {
        private readonly IBinaryTree _tree;

        public PreorderTreeWalker(IBinaryTree tree)
        {
            _tree = tree;
        }
        
        public void Walk(Action<ITreeNode> visitor)
        {
            if (_tree == null)
            {
                return;
            }

            _Walk(_tree.Root, visitor);
        }

        
        private void _Walk(ITreeNode node, Action<ITreeNode> visitor)
        {
            if (!_tree.IsNull(node))
            {
                visitor?.Invoke(node);
                _Walk(node.LeftChild, visitor);
                _Walk(node.RightChild, visitor);
            }
        }
    }
}