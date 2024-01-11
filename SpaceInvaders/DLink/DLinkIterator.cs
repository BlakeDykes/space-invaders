using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkIterator : IteratorBase
    {

        // ---------------------------------------
        // Data
        // ---------------------------------------
        private DLink pHead;
        private DLink pCur;
        private bool Done;


        // ---------------------------------------
        // Constructor
        // ---------------------------------------
        public DLinkIterator()
        {
            pHead = null;
            pCur = null;
            Done = true;
        }

        // ---------------------------------------
        // Methods
        // ---------------------------------------
        public override NodeBase First()
        {
            return this.pHead;
        }

        public override bool IsDone()
        {
            return this.Done;
        }

        public override NodeBase Current()
        {
            return this.pCur;
        }

        public override NodeBase Next()
        {
            Debug.Assert(pCur != null);

            DLink pDLink = (DLink)pCur;
            
            //Get Next, Assign to pCur
            pDLink = pDLink.pNext;
            pCur = pDLink;

            Done = pDLink == null ? true : false;

            return pDLink;
        }

        // reset pHead and pCur
        public override IteratorBase Reset(NodeBase _pHead)
        {
            if(_pHead != null)
            {
                pHead = (DLink)_pHead;
                pCur = pHead;
                Done = false;
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
