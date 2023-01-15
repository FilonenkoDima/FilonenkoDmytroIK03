namespace Trees
{
    public class BinaryTreeNode<T> : ITreeNode, IComparable<T>, IComparable
        where T : IComparable, IComparable<T>
    {
        public T Data { get; }
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public bool IsRoot => ParentNode.Value.ToString() == new BinaryTreeNode<T>(default).Value.ToString();

        public bool HasLeft => LeftChild.Value.ToString() != new BinaryTreeNode<T>(default).Value.ToString();

        public bool HasRight => RightChild.Value.ToString() != new BinaryTreeNode<T>(default).Value.ToString();

        public ITreeNode LeftChild
        {
            get;
            set;
        }

        public ITreeNode RightChild
        {
            get;
            set;
        }

        public ITreeNode ParentNode
        {
            get;
            private set;
        }

        public virtual void SetParent(ITreeNode parentNode)
        {
            ParentNode = parentNode;
        }

        public object Value => Data;

        public override string ToString() => $"Data: {Data?.ToString()}, Left: {HasLeft}, Right: {HasRight}, Parent: {!IsRoot}";
        

        public BinaryTreeNode<T> SetLeft(BinaryTreeNode<T> other)
        {
            LeftChild = other;
            other.SetParent(this);
            return this;
        }

        public BinaryTreeNode<T> SetRight(BinaryTreeNode<T> other)
        {
            RightChild = other;
            other.SetParent(this);
            return this;
        }

        public int CompareTo(object obj)
        {
            if (obj is BinaryTreeNode<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new ArgumentException("Incorrect type(must be BinaryTreeNode).");
            }
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}