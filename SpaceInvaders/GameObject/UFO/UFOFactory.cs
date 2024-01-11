using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOFactory
    {
        SpriteBatch pSpriteBatch;
        SpriteBatch pCollisionBatch;
        UFOGroup pUFOGroup;

        public UFOFactory(SpriteBatch.Name spriteBatch, SpriteBatch.Name collisionBatch)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatch);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBatch);
            Debug.Assert(this.pCollisionBatch != null);

            this.pUFOGroup = (UFOGroup)GameObjectNodeManager.Find(GameObject.Name.UFOGroup);
            Debug.Assert(this.pCollisionBatch != null);

        }

        public GameObject CreateUFO(float _x, float _y, int direction, Azul.Color color, bool moving)
        {
            GameObject pGO = null;

            pGO = new UFO(_x, _y, color, direction, moving);

            this.pUFOGroup.Add(pGO);
            this.pSpriteBatch.Attach(pGO);
            this.pCollisionBatch.Attach(pGO.poColObj.pColSprite);

            return pGO;
        }
    }
}
