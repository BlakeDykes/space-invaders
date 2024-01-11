using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColPairManager : ManagerBase
    {
        private static ColPairManager instance = null;
        private ColPair pCompColPair;
        private ColPair pActiveCol;

        private ColPairManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved) 
            : base(active, reserved, deltaGrow, initialReserved)
        {
            pActiveCol = null;
            pCompColPair = new ColPair();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);
            if(instance == null)
            {
                instance = new ColPairManager(active, reserved, deltaGrow, initialReserved);
            }
        }

        public static void Add(ColPair.Name name, GameObject pTreeA, GameObject pTreeB)
        {
            ColPairManager inst = ColPairManager.GetInstance();
            Debug.Assert(inst != null);

            ColPair pColPair = (ColPair)inst.BaseAdd();
            Debug.Assert(pColPair != null);

            pColPair.Set(name, pTreeA, pTreeB);
        }

        public static void AttachObserver(ColPair.Name name, Observer pObserver)
        {
            ColPairManager inst = ColPairManager.GetInstance();

            inst.pCompColPair.ColName = name;

            ColPair pColPair = (ColPair)inst.BaseFind(inst.pCompColPair);

            pColPair.AttachObserver(pObserver);
        }

        public static void Update()
        {
            ColPairManager inst = ColPairManager.GetInstance();
            Debug.Assert(inst != null);

            IteratorBase pIt = inst.BaseGetIterator();

            ColPair pNode = (ColPair)pIt.First();

            while(pIt.IsDone() != true)
            {
                inst.pActiveCol = pNode;

                inst.pActiveCol.Process();

                pNode = (ColPair)pIt.Next();
            }
        }

        private static ColPairManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static ColPair GetActivePair()
        {
            ColPairManager inst = ColPairManager.GetInstance();

            return inst.pActiveCol;
        }

        protected override NodeBase DerivedCreateNode()
        {
            return new ColPair();
        }
    }
}
