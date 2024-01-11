using System;

namespace SpaceInvaders
{
    public abstract class IteratorBase
    {
        public abstract NodeBase Next();
        public abstract bool IsDone();
        public abstract NodeBase First();
        public abstract NodeBase Current();
        public abstract IteratorBase Reset(NodeBase _pHead);
    }
}
