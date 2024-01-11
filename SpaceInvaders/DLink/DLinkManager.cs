using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkManager : CollectionBase
    {

        public DLink poHead;
        private DLinkIterator poIterator;

        public DLinkManager()
        {
            poHead = null;

            // LTN - DLinkManager
            poIterator = new DLinkIterator();
        }

        // Add Node to front of list
        public override void Add(NodeBase _node)
        {
            Debug.Assert(_node != null);

            DLink pNode = (DLink)_node;

            if (poHead != null)
            {
                pNode.pNext = poHead;
                poHead.pPrev = pNode;
            }
            poHead = pNode;
        }

        public override void AddByPriority(NodeBase _node, float priority)
        {
            Debug.Assert(_node != null);
            Debug.Assert(priority != 0);

            DLink pNode = (DLink)_node;
 
            if(poHead == null)
            {
                this.poHead = pNode;
                return;
            }

            DLink pCur = this.poHead;
            DLink pTemp = null;

            while (pCur != null)
            {
                if (pCur.ComparePriority(priority) == DLink.PriorityCompResult.GREATER_THAN)
                {
                    // Insert
                    pNode.pPrev = pTemp;
                    pNode.pNext = pCur;
                    pCur.pPrev = pNode;

                    if(pTemp != null)
                    {
                        pTemp.pNext = pNode;
                    }
                    // Add as first node
                    else
                    {
                        poHead = pNode;
                    }
                    return;
                }
                pTemp = pCur;
                pCur = pCur.pNext;
            }

            //Add to end
            pTemp.pNext = pNode;
            pNode.pPrev = pTemp;

            return;
        }

        public override void Prioritize(NodeBase _node, float priority)
        {
            Debug.Assert(_node != null);
            Debug.Assert(priority != 0.0f);
            Remove(_node);
            AddByPriority(_node, priority);
        }


        public override NodeBase GetFirst()
        {
            return poHead;
        }

        public override IteratorBase GetIterator()
        {
            return this.poIterator.Reset(this.poHead);
        }

        public override NodeBase Remove(NodeBase _node)
        {
            Debug.Assert(_node != null);
            if(this.poHead == null)
            {
                return null;
            }

            DLink pNode = (DLink)_node;

            if (pNode.pNext != null)
            {
                pNode.pNext.pPrev = pNode.pPrev;
            }
            if (pNode.pPrev != null)
            {
                pNode.pPrev.pNext = pNode.pNext;
            }
            else
            {
                //pNode was poHead, correct
                poHead = pNode.pNext;
            }
            pNode.Wash();

            return pNode;
        }

        public override NodeBase RemoveFromFront()
        {
            Debug.Assert(poHead != null);
            DLink pNode = poHead;

            // new head
            poHead = pNode.pNext;
            if (poHead != null)
            {
                poHead.pPrev = null;
            }

            pNode.Wash();
            return pNode;
        }

        public override void Wash()
        {
            Debug.Assert(poHead != null);
            DLink pCur = poHead;

            while(pCur != null)
            {
                DLink pTemp = pCur.pNext;
                Remove(pCur);
                pCur = pTemp;
            }
        }
    }
}
