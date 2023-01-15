using System;

namespace Trees
{
    public static class BinaryTreeSearcherFactory
    {
        public static ITreeSearcher Create(IBinaryTree tree, SearchMethod searchMethod)
        {
            return searchMethod switch
            {
                SearchMethod.Iterative => new IterativeBinaryTreeSearcher(tree),
                SearchMethod.Recursive => new RecursiveBinaryTreeSearcher(tree),
                _ => throw new ArgumentOutOfRangeException(nameof(searchMethod), searchMethod, null)
            };
        }

        public static ITreeSearcher<T> Create<T>(IBinaryTree tree, SearchMethod searchMethod)
            where T : class, ITreeNode
        {
            var searcher = Create(tree, searchMethod);
            var templatedSearcher = new TemplatedTreeSearcher<T>(searcher);
            return templatedSearcher;
        }
    }
}