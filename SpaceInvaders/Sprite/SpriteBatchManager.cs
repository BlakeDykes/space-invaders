using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatchManager : ManagerBase
    {
        private static SpriteBatchManager instance = null;
        private SpriteBatchManager psActiveSBMan;
        public float CurrentPriority;
        public SpriteBatch pBatchCompare;

        public SpriteBatchManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
            :base(active, reserved, deltaGrow, initialReserved)
        {
            CurrentPriority = 100;

            this.psActiveSBMan = null;

            // LTN - SpriteBatchManager
            pBatchCompare = new SpriteBatch();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(active != null);
            Debug.Assert(reserved != null);
            Debug.Assert(deltaGrow != 0);

            Debug.Assert(instance == null);

            if(instance == null)
            {
                // LTN - the process
                instance = new SpriteBatchManager(active, reserved, deltaGrow, initialReserved);
            }
        }



        public static SpriteBatch Add(SpriteBatch.Name name, float priority = 0.0f, int deltaGrow = 3, int initialReserve = 3)
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();
            Debug.Assert(inst != null);

            // Set batch priority
            float batchPriority = priority == 0.0f ? inst.CurrentPriority++ : priority;
 
            SpriteBatch pSB = (SpriteBatch)inst.BaseAdd(batchPriority);

            pSB.Set(batchPriority, name, deltaGrow, initialReserve);

            return pSB;
        }

        public static void Remove(SpriteBatch pNode)
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();

            inst.BaseRemove(pNode);
        }

        public static void Remove(SpriteNode pNode)
        {
            Debug.Assert(pNode != null);

            SpriteNodeManager pSpriteNodeManager = pNode.GetParent();
            Debug.Assert(pSpriteNodeManager != null);

            pSpriteNodeManager.BaseRemove(pNode);

        }

        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();
            Debug.Assert(inst != null);

            inst.pBatchCompare.BatchName = name;

            return (SpriteBatch)inst.BaseFind(inst.pBatchCompare);
        }

        public static void SetPriority(SpriteBatch.Name name, float priority)
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();
            Debug.Assert(inst != null);

            Debug.Assert(inst.pBatchCompare != null);
            inst.pBatchCompare.BatchName = name;

            SpriteBatch pSB = (SpriteBatch)inst.BaseFind(inst.pBatchCompare);

            pSB.SetPriority(priority);
            inst.poActive.Prioritize(pSB, priority);
        }

        private static SpriteBatchManager GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static void SetActive(SpriteBatchManager spriteBatchManager)
        {
            SpriteBatchManager inst = SpriteBatchManager.GetInstance();

            Debug.Assert(spriteBatchManager != null);
            inst.psActiveSBMan = spriteBatchManager;
        }

        private static SpriteBatchManager GetActiveInstance()
        {
            SpriteBatchManager inst = SpriteBatchManager.GetInstance();

            Debug.Assert(inst.psActiveSBMan != null);
            return inst.psActiveSBMan;
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteBatchManager
            return new SpriteBatch();
        }

        public static void UpdateAll()
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();
            Debug.Assert(inst != null);

            IteratorBase it = inst.BaseGetIterator();
            Debug.Assert(it != null);

            SpriteBatch pFirst = (SpriteBatch)it.First();
            SpriteBatch pTemp = pFirst;

            while (it.IsDone() == false)
            {
                pTemp.UpdateAll();
                pTemp = (SpriteBatch)it.Next();
            }
        }
        public static void RenderAll()
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();
            Debug.Assert(inst != null);

            IteratorBase it = inst.BaseGetIterator();
            Debug.Assert(it != null);

            SpriteBatch pCur = (SpriteBatch)it.First();

            while(it.IsDone() == false)
            {
                if(pCur.GetDrawEnable() == true)
                {
                    pCur.RenderAll();
                }
                pCur = (SpriteBatch)it.Next();
            }
        }

        public static void Clear()
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();
            Debug.Assert(inst != null);

            IteratorBase it = inst.BaseGetIterator();
            Debug.Assert(it != null);

            SpriteBatch pCur = (SpriteBatch)it.First();

            while (it.IsDone() == false)
            {
                pCur.Clear();
                pCur = (SpriteBatch)it.Next();
            }

            inst.BaseClear();
        }

        public static void DumpStats()
        {
            SpriteBatchManager inst = SpriteBatchManager.GetActiveInstance();
            Debug.Assert(inst != null);

            IteratorBase it = inst.BaseGetIterator();
            Debug.Assert(it != null);

            SpriteBatch pFirst = (SpriteBatch)it.First();
            SpriteBatch pTemp = pFirst;

            while(it.IsDone() == false)
            {
                pTemp.DumpStats();
                pTemp = (SpriteBatch)it.Next();
            }
        }
    }
}
