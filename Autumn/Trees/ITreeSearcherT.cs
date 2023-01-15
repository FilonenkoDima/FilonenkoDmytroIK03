namespace Trees
{
    public interface ITreeSearcher<out T> where T : class, ITreeNode
    {
        T Search(object key);
    }
}