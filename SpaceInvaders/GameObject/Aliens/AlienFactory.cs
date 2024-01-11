using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        SpriteBatch pSpriteBatch;
        SpriteBatch pCollisionBatch;

        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionBoxBatch)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBoxBatch);
            Debug.Assert(this.pCollisionBatch != null);
        }

        public GameObject CreateAlien(AlienBase.AlienType type, float _x, float _y, Azul.Color color)
        {
            GameObject pGO = null;

            switch (type)
            {
                case AlienBase.AlienType.AlienGrid:
                    pGO = new AlienGrid();
                    break;
                case AlienBase.AlienType.AlienColumn:
                    pGO = new AlienColumn();
                    break;
                case AlienBase.AlienType.Crab:
                    // STN - Alien GameObjects are created here and then deep copied in SpriteNodeManager
                    pGO = new AlienCrab(Sprite.Name.AlienCrab, _x, _y, color);
                    break;
                case AlienBase.AlienType.Octo:
                    // STN - Alien GameObjects are created here and then deep copied in SpriteNodeManager
                    pGO = new AlienOcto(Sprite.Name.AlienOcto, _x, _y, color);
                    break;
                case AlienBase.AlienType.Squid:
                    // STN - Alien GameObjects are created here and then deep copied in SpriteNodeManager
                    pGO = new AlienSquid(Sprite.Name.AlienSquid, _x, _y, color);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            this.pSpriteBatch.Attach(pGO);
            this.pCollisionBatch.Attach(pGO.poColObj.pColSprite);
            return pGO;
        }
    }
}
