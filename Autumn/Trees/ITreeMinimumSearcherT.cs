namespace Trees
{
    public interface ITreeMinimumSearcher<T> where T : class, ITreeNode
    {
        T Minimum(T startNode = null);
    }
}