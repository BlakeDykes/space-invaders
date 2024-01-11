using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombManager
    {
        private static BombManager instance = null;
        public BombGroup pBombGroup;

        private FallStrategy poStratHead;
        private int StrategyCount;

        private float NextDrop;

        AlienGrid pAlienGrid;

        Random rnd = new Random();


        private BombManager()
        {
            this.pBombGroup = new BombGroup();
            GameObjectNodeManager.Attach(pBombGroup, true);

            this.poStratHead = null;
            this.StrategyCount = 0;

            pAlienGrid = (AlienGrid)GameObjectNodeManager.Find(GameObject.Name.AlienGrid);

            this.NextDrop = (float)this.rnd.NextDouble() + 0.25f;
        }

        public static void Create()
        {
            if (instance == null)
            {
                instance = new BombManager();

                instance.AttachStrategy(FallStrategy.Name.Dagger);
                instance.AttachStrategy(FallStrategy.Name.Straight);
                instance.AttachStrategy(FallStrategy.Name.ZigZag);
            }
            else
            {
                BombManager inst = BombManager.GetInstance();
                inst.Reset();
            }
        }

        public void AttachStrategy(FallStrategy.Name name)
        {
            BombManager inst = BombManager.GetInstance();

            if(inst.GetStrategy(name) == null)
            {
                FallStrategy pStrat = FallStrategyFactory.CreateStrategy(name);
                pStrat.pNext = inst.poStratHead;
                inst.poStratHead = pStrat;

                StrategyCount++;
            }
        }

        public FallStrategy GetStrategy(FallStrategy.Name strategyName)
        {
            BombManager inst = BombManager.GetInstance();

            FallStrategy pStrat = inst.poStratHead;

            while(pStrat != null && pStrat.StrategyName != strategyName)
            {
                pStrat = (FallStrategy)pStrat.pNext;
            }

            return pStrat;
        }

        public static Bomb ActivateBomb()
        {
            BombManager inst = BombManager.GetInstance();

            Debug.Assert(inst.StrategyCount > 0);

            if(inst.pAlienGrid.GetColumnCount() == 0)
            {
                return null;
            }

            int fallStrat = inst.rnd.Next(0, inst.StrategyCount);
            int column = inst.rnd.Next(1, inst.pAlienGrid.GetColumnCount());

            // Select random FallStrategy
            FallStrategy pStrat = inst.poStratHead;
            for(int i = 0; i < fallStrat; i++)
            {
                pStrat = (FallStrategy)pStrat.pNext;
            }

            // Select random Column
            GameObject pColumn = (GameObject)inst.pAlienGrid.GetChild();
            for(int i = 1; i < column; i++)
            {
                pColumn = (GameObject)pColumn.pNext;
            }

            // GetLastAlien
            GameObject pAlien = (GameObject)pColumn.GetChild();
            GameObject pTemp = null;

            while (pAlien.pNext != null)
            {
                pTemp = (GameObject)pAlien.pNext;
                if (pAlien.y > pTemp.y)
                {
                    pAlien = pTemp;
                }
                else
                {
                    break;
                }
            }

            inst.NextDrop = (float)inst.rnd.NextDouble() + 0.5f;

            return (Bomb)BombFactory.CreateBomb(pAlien.x, pAlien.y, pStrat);
        }

        public static GameObject GetGroup()
        {
            BombManager inst = BombManager.GetInstance();

            return inst.pBombGroup;
        }

        public static float GetNextDrop()
        {
            BombManager inst = BombManager.GetInstance();

            return inst.NextDrop;
        }

        private void Reset()
        {
            this.pBombGroup = new BombGroup();
            GameObjectNodeManager.Attach(pBombGroup, true);

            this.pAlienGrid = (AlienGrid)GameObjectNodeManager.Find(GameObject.Name.AlienGrid);

            this.NextDrop = (float)this.rnd.NextDouble() + 0.25f;
        }
        
        private static BombManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
