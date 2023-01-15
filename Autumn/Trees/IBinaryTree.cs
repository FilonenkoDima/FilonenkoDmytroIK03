using System;

namespace Trees
{
    public interface IBinaryTree
    {
        ITreeNode Root { get; set; }

        bool IsNull(ITreeNode node);
        
        ITreeNode NullNode { get; }
    }
}