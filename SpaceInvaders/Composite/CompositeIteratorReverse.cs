using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CompositeIteratorReverse : IteratorBase
    {
        private Component pTail;
        private Component pCur;
        private bool Done;
        private CompositeIterator pFIt;

        public CompositeIteratorReverse(Component pStart)
        {
            Debug.Assert(pStart != null);
            Debug.Assert(pStart.ComponentType == Component.Type.Composite);

            // LTN - CompositeIteratorReverse
            pFIt = new CompositeIterator(pStart);
            Debug.Assert(pFIt != null);

            this.pTail = SetReverse(pStart);
            this.pCur = pTail;
        }

        public CompositeIteratorReverse()
        {
            this.pTail = null;
            this.pCur = null;
            this.Done = true;

            // LTN - CompositeIteratorReverse
            pFIt = new CompositeIterator();
        }

        public override NodeBase Current()
        {
            return this.pCur;
        }

        public override NodeBase First()
        {
            return this.pTail;
        }

        public override bool IsDone()
        {
            return this.Done;
        }

        public override NodeBase Next()
        {
            pCur = pCur.pReverse;
            Done = pCur == null ? true : false;
            return pCur;
        }

        public override IteratorBase Reset(NodeBase pStart)
        {
            if(pStart != null)
            {
                this.pTail = SetReverse((Component)pStart);
                this.pCur = pTail;
                this.Done = false;
            }
            else
            {
                privClear();
            }
            return this;
        }

        public void ResetCur()
        {
            this.pCur = this.pTail;
            Done = pCur == null ? true : false;
        }

        private Component SetReverse(Component pStart)
        {
            pFIt.Reset(pStart);

            Component pPrevNode = pStart;
            Component pNode = (Component)pFIt.Current();

            while (pFIt.IsDone() != true)
            {
                pPrevNode = pNode;

                pNode = (Component)pFIt.Next();

                if (pNode != null)
                {
                    pNode.pReverse = pPrevNode;
                }
            }

            return pPrevNode;
        }

        private void privClear()
        {
            this.pTail = null;
            this.pCur = null;
            this.Done = true;

        }
    }
}
