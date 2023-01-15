namespace Trees
{
    public interface ITreeNode
    {
        ITreeNode LeftChild { get; set; }
        ITreeNode RightChild { get; set; }
        ITreeNode ParentNode { get; }
        
        void SetParent(ITreeNode parentNode);
        
        object Value { get; }
    }
}