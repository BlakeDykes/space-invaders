using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipFactory
    {
        private static ShipFactory instance = null;
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pCollisionBatch;
        private ShipGroup pShipGroup;

        private ShipFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionBoxBatch)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBoxBatch);
            Debug.Assert(this.pCollisionBatch != null);

            pShipGroup = (ShipGroup)GameObjectNodeManager.Find(GameObject.Name.ShipGroup);
            Debug.Assert(pShipGroup != null);
        }

        public static void Create(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionBoxBatch)
        {
            if (instance == null)
            {
                instance = new ShipFactory(spriteBatchName, collisionBoxBatch);
            }
            else
            {
                ShipFactory inst = ShipFactory.GetInstance();
                inst.Reset(spriteBatchName, collisionBoxBatch);
            }
        }

        public static GameObject CreateShip()
        {
            ShipFactory inst = ShipFactory.GetInstance();

            Player pPlayer = PlayerManager.GetCurrentPlayer();
            Debug.Assert(pPlayer != null);
            pPlayer.RemoveLife();

            GameObject pGO = new Ship(GameObject.Name.Ship, Sprite.Name.Ship, Constants.SHIP_STARTING_X_POS, Constants.SHIP_Y_POS, Constants.GREEN);
            inst.pShipGroup.Add(pGO);
            inst.pSpriteBatch.Attach(pGO);
            inst.pCollisionBatch.Attach(pGO.poColObj.pColSprite);
            return pGO;
    
        }

        private void Reset(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionBoxBatch)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBoxBatch);
            Debug.Assert(this.pCollisionBatch != null);

            pShipGroup = (ShipGroup)GameObjectNodeManager.Find(GameObject.Name.ShipGroup);
            Debug.Assert(pShipGroup != null);
        }

        private static ShipFactory GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }
    }
}
