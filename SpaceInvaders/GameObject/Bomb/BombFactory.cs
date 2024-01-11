using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombFactory
    {
        private static BombFactory instance = null;
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pCollisionBatch;
        private BombGroup pBombGroup;

        private BombFactory(SpriteBatch.Name sbName, SpriteBatch.Name colSBName)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(sbName);
            Debug.Assert(this.pSpriteBatch != null);
            
            this.pCollisionBatch = SpriteBatchManager.Find(colSBName);
            Debug.Assert(this.pCollisionBatch != null);

            this.pBombGroup = (BombGroup)GameObjectNodeManager.Find(GameObject.Name.BombGroup);
            Debug.Assert(this.pBombGroup != null);
        }

        public static void Create(SpriteBatch.Name sbName, SpriteBatch.Name colSBName)
        {
            if(instance == null)
            {
                instance = new BombFactory(sbName, colSBName); 
            }
            else
            {
                BombFactory inst = BombFactory.GetInstance();

                inst.Reset(sbName, colSBName);
            }
        }

        public static GameObject CreateBomb(float _x, float _y, FallStrategy pStrategy)
        {
            BombFactory inst = BombFactory.GetInstance();

            GameObject pGo = null;

            GameObjectNode pGameObjectNode = GhostManager.Find(GameObject.Name.Bomb);

            if(pGameObjectNode != null)
            {
                pGo = pGameObjectNode.pGameObj;
                GhostManager.Remove(pGameObjectNode);
                ((Bomb)pGo).Recycle(_x, _y, pStrategy);
            }
            else
            {
                pGo = new Bomb(GameObject.Name.Bomb, pStrategy, _x, _y, BombBase.BombType.Bomb);
            }

            inst.pBombGroup.Add(pGo);
            inst.pSpriteBatch.Attach(pGo);
            inst.pCollisionBatch.Attach(pGo.poColObj.pColSprite);

            return pGo;
        }

        private static BombFactory GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
        private void Reset(SpriteBatch.Name sbName, SpriteBatch.Name colSBName)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(sbName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(colSBName);
            Debug.Assert(this.pCollisionBatch != null);

            this.pBombGroup = (BombGroup)GameObjectNodeManager.Find(GameObject.Name.BombGroup);
            Debug.Assert(this.pBombGroup != null);
        }
    }
}
