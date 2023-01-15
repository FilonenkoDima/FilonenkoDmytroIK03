using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees
{
    public sealed class BinaryTree<T> : IBinaryTree
        where T : IComparable, IComparable<T>
    {
        private BinaryTreeNode<T> _root;
        private readonly BinaryTreeNode<T> _nil;
        
        public BinaryTree()
        {
            _nil = new BinaryTreeNode<T>(default);
            _nil.LeftChild = _nil.RightChild = _nil;
            _root = _nil;
        }
        
        public ITreeNode NullNode => _nil;

        public ITreeNode Root
        {
            get => _root;
            set => _root = value as BinaryTreeNode<T>;
        }

        public bool IsNull(ITreeNode node) => node == _nil;

        public BinaryTreeNode<T> CreateNode(T data)
        {
            var node = new BinaryTreeNode<T>(data);
            node.LeftChild = node.RightChild = _nil;
            return node;
        }

        public override string ToString()
        {
            return this.GetBinaryTreeString();
        }

        public void SetRoot(BinaryTreeNode<T> root)
        {
            _root = root;
            _root.SetParent(_nil);
        }

        public IEnumerable<BinaryTreeNode<T>> Enumerate(T minKey, T maxKey, BinaryTreeNode<T> rootNode = null)
        {
            if (minKey.CompareTo(maxKey) == 1 || minKey.CompareTo(maxKey) == 0)
            {
                throw new ArgumentException($"minKey should be less than maxKey, minKey: {minKey}, maxKey: {maxKey}");
            }

            rootNode ??= Root as BinaryTreeNode<T>;

            if (rootNode == null)
            {
                throw new InvalidOperationException("root is null or it is not BinaryTreeNode<T>");
            }

            var outputList = new List<BinaryTreeNode<T>>();
            var currentKey = rootNode.Data;
            if ((minKey.CompareTo(currentKey) == -1 || minKey.CompareTo(currentKey) == 0) && (currentKey.CompareTo(maxKey) == -1 || currentKey.CompareTo(maxKey) == 0))
            {
                outputList.Add(rootNode);
            }

            if ((minKey.CompareTo(currentKey) == -1 || minKey.CompareTo(currentKey) == 0) && !IsNull(rootNode.LeftChild))
            {
                outputList.AddRange(Enumerate(minKey, maxKey, rootNode.LeftChild as BinaryTreeNode<T>));
            }

            if ((currentKey.CompareTo(maxKey) == -1 || currentKey.CompareTo(maxKey) == 0) && !IsNull(rootNode.RightChild))
            {
                outputList.AddRange(Enumerate(minKey, maxKey, rootNode.RightChild as BinaryTreeNode<T>));
            }

            return outputList;
        }

        public BinaryTreeNode<T> FindSuccessor(ITreeNode node) => this.Successor(node) as BinaryTreeNode<T>;

        public BinaryTreeNode<T> FindPredecessor(ITreeNode node) => this.Predecessor(node) as BinaryTreeNode<T>;

        public ITreeNode CreateSearcher(SearchMethod method, T value)
        {
            var searcher = BinaryTreeSearcherFactory.Create<BinaryTreeNode<T>>(this, method);
            return searcher.Search(value);
        }

        public void Insert(ITreeNode node) => (this as IBinaryTree).Insert(node);

        public ITreeNode CreateMaximumSearcher(BinaryTreeNode<T> node, SearchMethod method)
        {
             var searcher = TreeMaximumSearcherFactory.Create<BinaryTreeNode<T>>(this, method);
            return searcher.Maximum(node);
        }

        public ITreeNode CreateMinimumSearcher(BinaryTreeNode<T> node, SearchMethod method)
        {
            var searcher = TreeMinimumSearcherFactory.Create<BinaryTreeNode<T>>(this, method);
            return searcher.Minimum(node);
        }
    }
}