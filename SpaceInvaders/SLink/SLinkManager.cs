using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SLinkManager : CollectionBase
    {
        public SLink poHead;
        private SLinkIterator poIterator;

        public SLinkManager()
        {
            this.poHead = null;
            this.poIterator = new SLinkIterator();
        }

        public override void Add(NodeBase _node)
        {
            Debug.Assert(_node != null);

            SLink pNode = (SLink)_node;

            pNode.pNext = this.poHead;
            this.poHead = pNode;
        }

        public override void AddByPriority(NodeBase _node, float priority)
        {
            Debug.Assert(_node != null);

            SLink pNode = (SLink)_node;

            if(this.poHead == null)
            {
                this.poHead = pNode;
                return;
            }

            SLink pCur = this.poHead;
            SLink pTemp = null;
            while (pCur != null)
            {
                if(pCur.ComparePriority(priority) == SLink.PriorityCompResult.GREATER_THAN)
                {
                    pNode.pNext = pCur;

                    if(pTemp != null)
                    {
                        pTemp.pNext = pNode;
                    }
                    return;
                }
                pTemp = pCur;
                pCur = pCur.pNext;
            }

            pTemp.pNext = pNode;
        }

        public override NodeBase GetFirst()
        {
            return this.poHead;
        }

        public override IteratorBase GetIterator()
        {
            return this.poIterator.Reset(this.poHead);
        }

        public override void Prioritize(NodeBase _node, float priority)
        {
            Debug.Assert(_node != null);
            Debug.Assert(priority != 0.0f);
            Remove(_node);
            AddByPriority(_node, priority);
        }

        public override NodeBase Remove(NodeBase _node)
        {
            Debug.Assert(_node != null);
            Debug.Assert(this.poHead != null);

            SLink pNode = (SLink)_node;
            SLink pCur = this.poHead;
            SLink pPrev = null;

            // node is poHead
            if(pCur == pNode)
            {
                this.poHead = pNode.pNext;
                pNode.Wash();
                return pNode;
            }

            pPrev = pCur;
            pCur = pCur.pNext;
            
            while(pCur != null)
            {
                if(pCur == pNode)
                {
                    pPrev.pNext = pCur.pNext;
                    pNode.Wash();
                    return pNode;
                }

                pPrev = pCur;
                pCur = pCur.pNext;
            }

            // node not found
            return null;
        }

        public override NodeBase RemoveFromFront()
        {
            Debug.Assert(this.poHead != null);
            SLink pNode = this.poHead;

            this.poHead = pNode.pNext;

            pNode.Wash();
            return pNode;
        }

        public override void Wash()
        {
            Debug.Assert(poHead != null);
            SLink pCur = poHead;

            while(pCur != null)
            {
                SLink pTemp = pCur.pNext;
                Remove(pCur);
                pCur = pTemp;
            }
        }
    }
}
