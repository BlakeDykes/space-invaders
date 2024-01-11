using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SLink : NodeBase
    {
        public SLink pNext;

        public enum PriorityCompResult
        {
            GREATER_THAN,
            LESS_THAN,

            undefined
        }


        public SLink()
        {
            this.pNext = null;
        }

        public override void Wash()
        {
            this.pNext = null;
        }

        // used to compare in priority queue SLinks
        virtual public PriorityCompResult ComparePriority(float priority)
        {
            Debug.Assert(false);
            return PriorityCompResult.undefined;
        }
    }
}
