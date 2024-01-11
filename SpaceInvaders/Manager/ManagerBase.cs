using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ManagerBase
    {
        public int DeltaGrow;
        public int NumReserved;
        public int NumActive;
        public int TotalNodes;
        public int PeakActive;
        public int PeakReserved;
        public int PeakNodes;
        public CollectionBase poActive;
        public CollectionBase poReserved;

        public ManagerBase(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            this.poActive = active;
            this.poReserved = reserved;
            this.DeltaGrow = deltaGrow;
        }

        public NodeBase BaseAdd(float priority = 0.0f)
        {
            Debug.Assert(poReserved != null);
            Debug.Assert(poActive != null);

            IteratorBase it = poReserved.GetIterator();
            Debug.Assert(it != null);

            // Refill reserve if empty
            while(it.First() == null)
            {
                AddToReserve(DeltaGrow);
                it = poReserved.GetIterator();
            }

            NodeBase pNode = poReserved.RemoveFromFront();
            Debug.Assert(pNode != null);

            if (priority == 0)
            {
                poActive.Add(pNode);
            }
            else
            {
                poActive.AddByPriority(pNode, priority);
            }
            
            ManageStats(-1, 1);

            return pNode;
        }

        public NodeBase BaseRemove(NodeBase pNode)
        {
            Debug.Assert(pNode != null);

            NodeBase pRem = poActive.Remove(pNode);

            poReserved.Add(pRem);

            ManageStats(1, -1);

            return pRem;
        }

        public NodeBase BaseFind(NodeBase pNode)
        {
            IteratorBase it = poActive.GetIterator();
            Debug.Assert(it != null);

            NodeBase pCur = it.First();

            while (it.IsDone() != true)
            {
                if (pCur.Compare(pNode) == true)
                {
                    break;
                }
                pCur = it.Next();
            }

            return pCur;
        }

        public void BaseClear()
        {
            IteratorBase it = poActive.GetIterator();
            Debug.Assert(it != null);

            NodeBase pCur = it.First();
            NodeBase pTemp = null;

            while (it.IsDone() != true)
            {
                pTemp = it.Next();
                BaseRemove(pCur);
                pCur = pTemp;
            }
        }

        public void AddToReserve(int count)
        {
            for(int i = 0; i < count; i++)
            {
                NodeBase pNode = this.DerivedCreateNode();
                poReserved.Add(pNode);
            }
            ManageStats(count, 0);
        }

        public void SetReserve(int deltaGrow, int initialReserved)
        {
            this.DeltaGrow = deltaGrow;

            if(initialReserved > this.NumReserved)
            {
                this.AddToReserve(initialReserved - this.NumReserved);
            }
        }

        private void ManageStats(int reserveChange, int activeChange)
        {
            NumReserved += reserveChange;
            PeakReserved = PeakReserved < NumReserved ? NumReserved : PeakReserved;

            NumActive += activeChange;
            PeakActive = PeakActive < NumActive ? NumActive : PeakActive;

            TotalNodes = NumActive + NumReserved;
            PeakNodes = PeakNodes < TotalNodes ? TotalNodes : PeakNodes;
        }

        public IteratorBase BaseGetIterator()
        {
            return this.poActive.GetIterator();
        }

        public void BaseDumpStats()
        {
            Debug.WriteLine("Peak Active - {0}\nPeak Reserved - {1}\nPeak Nodes - {2}\n", PeakActive, PeakReserved, PeakNodes);
        }

        //----------------------------------------------------------------------
        // Abstract methods
        //----------------------------------------------------------------------
        abstract protected NodeBase DerivedCreateNode();


    }
}
