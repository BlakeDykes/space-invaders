using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WallFactory
    {
        SpriteBatch pSpriteBatch;
        SpriteBatch pCollisionBatch;

        public WallFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionBoxBatch)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBoxBatch);
            Debug.Assert(this.pCollisionBatch != null);
        }

        public GameObject CreateWalls(WallBase.WallType type)
        {
            GameObject pGO = null;
            
            if(type == WallBase.WallType.Group)
            {
                pGO = new WallGroup(GameObject.Name.WallGroup, Sprite.Name.NullProxy, 0.0f, 0.0f);
                GameObjectNodeManager.Attach(pGO);
                return pGO;
            }

            switch (type) 
            {
                case WallBase.WallType.Top:
                    pGO = new WallTop(GameObject.Name.WallTop, Sprite.Name.NullProxy, 450.0f, Constants.GAMEPLAY_TOP_TEXT_Y - 75.0f, 900.0f, 50.0f, Constants.TRANSPARENT);
                    break;
                case WallBase.WallType.Left:
                    pGO = new WallLeft(GameObject.Name.WallLeft, Sprite.Name.NullProxy, 5.0f, 500.0f, 10.0f, 1024.0f, Constants.TRANSPARENT);
                    break;
                case WallBase.WallType.Right:
                    pGO = new WallRight(GameObject.Name.WallRight, Sprite.Name.NullProxy, 891.0f, 500.0f, 10.0f, 1024.0f, Constants.TRANSPARENT);
                    break;
                case WallBase.WallType.Bottom:
                    pGO = new WallBottom(GameObject.Name.WallBottom, Sprite.Name.Wall_Bottom, Constants.SCREEN_X * .5f, 94.0f, 890.0f, 10.0f, Constants.GREEN);
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
