﻿namespace Trees
{
    public class TemplatedTreeSearcher<T> : ITreeSearcher<T> where T : class, ITreeNode
    {
        private readonly ITreeSearcher _searcher;

        public TemplatedTreeSearcher(ITreeSearcher searcher)
        {
            _searcher = searcher;
        }

        public T Search(object key)
        {
            return _searcher.Search(key) as T;
        }
    }
}