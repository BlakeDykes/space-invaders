using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Component : ColVisitor
    {
        public Component pParent;
        public Component pReverse;
        public Type ComponentType;

        public int LeafCount;

        public enum Type
        { 
            Composite,
            Leaf,

            Uninitialized
        }

        public Component GetParent()
        {
            return this.pParent;
        }

        public virtual void Recycle()
        {
            this.pParent = null;
            this.pReverse = null;
        }

        public abstract void Update();

        public abstract void Add(Component pComp);

        public int GetLeafCount()
        {
            return this.LeafCount;
        }

        public virtual void SetChild(Component _pHead)
        {
            // Override in Composite
        }
        public virtual Component GetChild()
        {
            // Override in Composite
            return null;
        }
        public virtual void Remove(Component pComp)
        {
            // Override in Composite
        }

    }
}
