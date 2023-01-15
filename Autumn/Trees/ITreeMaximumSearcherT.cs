namespace Trees
{
    public interface ITreeMaximumSearcher<T> where T : class, ITreeNode
    {
        T Maximum(T startNode);
    }
}