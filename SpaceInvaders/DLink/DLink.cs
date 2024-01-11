using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public abstract class DLink : NodeBase
    {
        public DLink pNext;
        public DLink pPrev;

        public enum PriorityCompResult
        {
            GREATER_THAN,
            LESS_THAN,

            undefined
        }

        public DLink()
        {
            this.pNext = null;
            this.pPrev = null;
        }
        public override void Wash()
        {
            this.pNext = null;
            this.pPrev = null;
        }

        // used to compare in priority queue DLinks
        virtual public PriorityCompResult ComparePriority(float priority)
        {
            Debug.Assert(false);
            return PriorityCompResult.undefined;
        }
    }
}
