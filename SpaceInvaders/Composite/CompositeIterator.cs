using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CompositeIterator : IteratorBase
    {
        public Component pCur;
        public Component pHead;
        public bool Done;

        public CompositeIterator()
        {
            this.pHead = null;
            this.pCur = null;
            Done = true;
        }

        public CompositeIterator(Component _pHead)
        {
            this.pHead = _pHead;
            this.pCur = _pHead;
            Done = _pHead == null ? true : false;
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
            Component pParent = pCur.GetParent();
            Component pChild = pCur.GetChild();

            if (pChild != null)
            {
                pCur = pChild;
            }

            else
            {
                pCur = (Component)pCur.pNext;

                while (pParent != null && pCur == null)
                {
                    pCur = (Component)pParent.pNext;
                    pParent = pParent.GetParent();
                }
                
            }

            if(pCur == null)
            {
                this.Done = true;
            }
            
            return pCur;
        }

        public override IteratorBase Reset(NodeBase _pHead)
        {
            if (_pHead != null)
            {
                pHead = (Component)_pHead;
                pCur = pHead;
                Done = pHead == null ? true : false;
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

        public static Component GetSibling(Component pNode)
        {
            Debug.Assert(pNode != null);
            return (Component)pNode.pNext;
        }
    }
}
