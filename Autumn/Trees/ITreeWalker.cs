using System;
using System.Threading.Tasks;

namespace Trees
{
    public interface ITreeWalker
    {
        void Walk(Action<ITreeNode> visitor);

    }
}