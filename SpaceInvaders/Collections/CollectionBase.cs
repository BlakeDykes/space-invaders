using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollectionBase
    {
        public abstract NodeBase GetFirst();
        public abstract void Add(NodeBase _node);
        public abstract void AddByPriority(NodeBase _node, float priority);
        public abstract NodeBase RemoveFromFront();
        public abstract NodeBase Remove(NodeBase _node);
        public abstract IteratorBase GetIterator();
        public abstract void Prioritize(NodeBase _node, float priority);
        public abstract void Wash();
    }
}
