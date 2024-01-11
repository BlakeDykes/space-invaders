using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SLinkIterator : IteratorBase
    {
        private SLink pHead;
        private SLink pCur;
        private bool Done;

        public SLinkIterator()
        {
            this.pHead = null;
            this.pCur = null;
            this.Done = true;
        }

        public override NodeBase Current()
        {
            return this.pCur;
        }

        public override NodeBase First()
        {
            return this.pHead;
        }

        public override bool IsDone()
        {
            return this.Done;
        }

        public override NodeBase Next()
        {
            Debug.Assert(this.pHead != null);
            Debug.Assert(this.pCur != null);

            this.pCur = pCur.pNext;
            if(this.pCur == null)
            {
                this.Done = true;
            }

            return this.pCur;
        }

        public override IteratorBase Reset(NodeBase _pHead)
        {
            if(_pHead != null)
            {
                this.pHead = (SLink)_pHead;
                this.pCur = this.pHead;
                this.Done = false;
            }
            else
            {
                this.privClear();
            }
            return this;
        }

        private void privClear()
        {
            this.pHead = null;
            this.pCur = null;
            this.Done = true;
        }
    }
}
