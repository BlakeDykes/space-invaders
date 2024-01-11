using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissleFactory
    {
        private static MissleFactory instance = null;
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pCollisionBatch;
        private MissleGroup pMissleGroup;

        private MissleFactory(SpriteBatch.Name sbName, SpriteBatch.Name collisionBoxBatch)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(sbName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBoxBatch);
            Debug.Assert(this.pCollisionBatch != null);

            pMissleGroup = (MissleGroup)GameObjectNodeManager.Find(GameObject.Name.MissleGroup);
            Debug.Assert(pMissleGroup != null);
        }

        public static void Create(SpriteBatch.Name sbName, SpriteBatch.Name collisionBoxBatch)
        {
            if (instance == null)
            {
                instance = new MissleFactory(sbName, collisionBoxBatch);
            }
            else
            {
                MissleFactory inst = MissleFactory.GetInstance();

                inst.Reset(sbName, collisionBoxBatch);
            }
        }

        public static GameObject CreateMissle(float _x, float _y)
        {
            MissleFactory inst = MissleFactory.GetInstance();

            GameObject pGO = null;

            GameObjectNode pGameObjectNode = GhostManager.Find(GameObject.Name.Missle);

            if(pGameObjectNode != null)
            {
                pGO = pGameObjectNode.pGameObj;
                GhostManager.Remove(pGameObjectNode);
                ((Missle)pGO).Recycle(_x, _y);
            }
            else
            {
                pGO = new Missle(GameObject.Name.Missle, Sprite.Name.Missle, _x, _y + 10.0f, Constants.GREEN);
            }

            inst.pMissleGroup.Add(pGO);
            inst.pMissleGroup.BaseUpdateColBox(inst.pMissleGroup, out inst.pMissleGroup.LeafCount);
            inst.pSpriteBatch.Attach(pGO);
            inst.pCollisionBatch.Attach(pGO.poColObj.pColSprite);
            return pGO;

        }

        private void Reset(SpriteBatch.Name sbName, SpriteBatch.Name collisionBoxBatch)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(sbName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBoxBatch);
            Debug.Assert(this.pCollisionBatch != null);

            pMissleGroup = (MissleGroup)GameObjectNodeManager.Find(GameObject.Name.MissleGroup);
            Debug.Assert(pMissleGroup != null);
        }

        private static MissleFactory GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
